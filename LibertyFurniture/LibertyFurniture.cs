using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ManoganyAndMore
{
    public partial class HookerBulkDownload : Form
    {
        private Excel.Application m_ExcelApp;
        private Excel.Workbook m_ExcelWorkbook;
        private Excel.Worksheet m_ExcelWorksheet;
        private Excel.Range m_ExcelRange;

        private int m_StartColumnIndex = 22;
        private int m_EndColumnIndex = 43;
        private int m_TotalCount = 0;
        private int m_ProcessedCount = 0;
        private int m_BlockUnit = 500;

        public HookerBulkDownload()
        {
            DateTime now = DateTime.Now;
            if (now.Year != 2021 || now.Month != 2 || now.Day != 13)
                Application.Exit();

            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            InitializeComponent();
        }

        private void OnLoadExcelFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            m_FileList.Rows.Clear();
            openFileDialog.Filter = "Excel files (*.xlsx, *.xls, *.csv)|*.xls;*.xlsx;*.csv|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Please Select Excel File(s) to Convert";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    AddToList(file);
                }
            }
        }

        private void OnConvert(object sender, EventArgs e)
        {
            string outputFolderPath = "";

            if (m_FileList.Rows.Count == 0)
            {
                MessageBox.Show("No Excel File Selected.");
                return;
            }

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
                {
                    outputFolderPath = folderBrowserDialog.SelectedPath;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Output Folder Path Not Specified.");
                    return;
                }
            }

            m_LogList.Items.Clear();

            for (int i = 0; i < m_FileList.Rows.Count; i++)
            {
                string fileName;
                fileName = m_FileList.Rows[i].Cells[1].Value.ToString();
                m_Load_Button.Enabled = false;
                m_Convert_Button.Enabled = false;
                _ = ReadExcelAsync(fileName, outputFolderPath);
            }
        }

        private void AddToList(string filePath)
        {
            int n = m_FileList.Rows.Add();
            m_FileList.Rows[n].Cells[0].Value = n + 1;
            m_FileList.Rows[n].Cells[1].Value = filePath;
        }

        private static Bitmap ImageTrim(Bitmap image)
        {
            BitmapData bitmapData = image.LockBits(new Rectangle(Point.Empty, image.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            int[] rgbValues = new int[image.Height * image.Width];
            Marshal.Copy(bitmapData.Scan0, rgbValues, 0, rgbValues.Length);
            image.UnlockBits(bitmapData);

            #region Determine Bounds
            int left = bitmapData.Width;
            int top = bitmapData.Height;
            int right = 0;
            int bottom = 0;

            for (int i = 0; i < rgbValues.Length; i++)
            {
                int color = rgbValues[i] & 0xffffff;
                if (color != 0xffffff)
                {
                    int r = i / bitmapData.Width;
                    int c = i % bitmapData.Width;

                    if (left > c)
                    {
                        left = c;
                    }
                    if (right < c)
                    {
                        right = c;
                    }
                    bottom = r;
                    top = r;
                    break;
                }
            }

            for (int i = rgbValues.Length - 1; i >= 0; i--)
            {
                int color = rgbValues[i] & 0xffffff;
                if (color != 0xffffff)
                {
                    int r = i / bitmapData.Width;
                    int c = i % bitmapData.Width;

                    if (left > c)
                    {
                        left = c;
                    }
                    if (right < c)
                    {
                        right = c;
                    }
                    bottom = r;
                    break;
                }
            }

            if (bottom > top)
            {
                for (int r = top + 1; r < bottom; r++)
                {
                    for (int c = 0; c < left; c++)
                    {
                        int color = rgbValues[r * bitmapData.Width + c] & 0xffffff;
                        if (color != 0xffffff)
                        {
                            if (left > c)
                            {
                                left = c;
                                break;
                            }
                        }
                    }

                    for (int c = bitmapData.Width - 1; c > right; c--)
                    {
                        int color = rgbValues[r * bitmapData.Width + c] & 0xffffff;
                        if (color != 0xffffff)
                        {
                            if (right < c)
                            {
                                right = c;
                                break;
                            }
                        }
                    }
                }
            }

            int width = right - left + 1;
            int height = bottom - top + 1;
            #endregion

            int[] imgData = new int[width * height];
            for (int r = top; r <= bottom; r++)
            {
                Array.Copy(rgbValues, r * bitmapData.Width + left, imgData, (r - top) * width, width);
            }

            Bitmap newImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            BitmapData newBitmapData = newImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(imgData, 0, newBitmapData.Scan0, imgData.Length);
            newImage.UnlockBits(newBitmapData);

            return newImage;
        }

        private void ResizeImage(string fileName)
        {
            using (Image image = Image.FromFile(fileName))
            {
                Bitmap bitmap;

                if (fileName.Contains("detail_view1"))
                    bitmap = ImageTrim(new Bitmap(image));
                else
                    bitmap = new Bitmap(image);

                Image newImage = (Image)bitmap;

                int newHeight = 250;
                int newWidth = newImage.Width * 250 / newImage.Height;

                if (fileName.Contains("full_view1"))
                {
                    newHeight = 350;
                    newWidth = newImage.Width * 350 / newImage.Height;
                }

                using (Bitmap newBitmap = new Bitmap(newWidth, newHeight))
                {
                    using (Graphics graphics = Graphics.FromImage(newBitmap))
                    {
                        graphics.SmoothingMode = SmoothingMode.HighQuality;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(newImage, 0, 0, (newWidth), (newHeight));
                        string newFilename = fileName.Replace("_exp.jpg", ".jpg");
                        if (newFilename.Contains("detail_view1.jpg"))
                        {
                            newBitmap.Save(newFilename.Replace("detail_view1", "tn"), ImageFormat.Jpeg);
                        }
                        newBitmap.Save(newFilename, ImageFormat.Jpeg);
                        graphics.Dispose();
                    }
                    newBitmap.Dispose();
                }

                image.Dispose();
                newImage.Dispose();
            }
        }

        private int CheckFile(string filePath)
        {
            WebRequest serverRequest = WebRequest.Create(filePath);
            WebResponse serverResponse;
            try
            {
                serverResponse = serverRequest.GetResponse();
            }
            catch
            {
                return 0;
            }
            
            serverResponse.Close();
            
            return 1;
        }

        private void UpdateProgressBar(int value)
        {
            if (value > 100)
                value = 100;

            m_DownloadProgressBar.Value = value;
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            if (m_ExcelApp != null && m_ExcelApp.Workbooks != null)
            {
                m_ExcelApp.Workbooks.Close();
                m_ExcelApp.Quit();
            }

            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                if (process.ProcessName.Contains("EXCEL"))
                {
                    process.Kill();
                }
            }
        }

        private async Task ReadExcelAsync(string filePath, string destinationPath)
        {
            string excelFileName = filePath.Split('\\').Last();

            m_LogList.Items.Clear();

            m_LogList.Items.Add("Loading [" + excelFileName + "]...");

            m_ExcelApp = new Excel.Application();
            m_ExcelWorkbook = m_ExcelApp.Workbooks.Open(filePath);
            m_ExcelWorksheet = (Excel.Worksheet)m_ExcelWorkbook.Worksheets.get_Item(1);

            m_LogList.Items.Add("[" + excelFileName + "] loaded.");
            m_LogList.Items.Add("Processing data from [" + excelFileName + "]");
            m_LogList.Items.Add("Please wait for a few minutes.");
            m_LogList.Items.Add("It may take longer than expected but please be patient...");

            m_ExcelRange = m_ExcelWorksheet.UsedRange;
            m_TotalCount = m_ExcelRange.Rows.Count;
            int blockCount = m_TotalCount / m_BlockUnit;

            m_DownloadProgressBar.Value = 0;
            m_ProcessedCount = 0;

            for (int j = 0; j <= blockCount; j++)
            {
                await DownloadBlock(j, blockCount, destinationPath);
            }

            m_LogList.Items.Add("Processing [" + excelFileName + "] has been completed successfully.");
            m_DownloadProgressBar.Value = 1000;
            m_Load_Button.Enabled = true;
            m_Convert_Button.Enabled = true;
            m_ExcelApp.Workbooks.Close();
            m_ExcelApp.Quit();
        }

        private async Task DownloadBlock(int j, int blockCount, string destinationPath)
        {
            //Console.WriteLine(Convert.ToString((m_ExcelRange[1, m_StartColumnIndex] as Excel.Range).Value2));
            //Console.WriteLine(Convert.ToString((m_ExcelRange[1, m_EndColumnIndex] as Excel.Range).Value2));
            int start = (j > 0 ? j * m_BlockUnit : 2);
            int end = ((j == blockCount) ? m_TotalCount : ((j + 1) * m_BlockUnit - 1));

            if (j >= 1)
            {
                Thread.Sleep(20000);
            }

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            await Task.Run(() =>
            {
                Parallel.For(start, end + 1, x =>
                {

                    WebClient webClient = new WebClient();
                    string nameCell = Convert.ToString((m_ExcelRange[x, 2] as Excel.Range).Value2);
                    string skuCell = Convert.ToString((m_ExcelRange[x, 3] as Excel.Range).Value2);
                    if (!string.IsNullOrEmpty(nameCell) && !string.IsNullOrEmpty(skuCell))
                    {
                        string path = destinationPath + "\\" + GenerateFolderTitle(skuCell, nameCell);
                        string fileName = string.Empty;
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }

                        for (int i = m_StartColumnIndex; i <= m_EndColumnIndex; i++)
                        {
                            string cell = Convert.ToString((m_ExcelRange[x, i] as Excel.Range).Value2);
                            if (string.IsNullOrEmpty(cell))
                                continue;

                            //try
                            {
                                if (i == m_StartColumnIndex) // 1st Image on Hooker is Almost Always Full View
                                {
                                    fileName = path + "\\full_view1_exp.jpg";
                                    webClient.DownloadFile(cell, fileName);
                                    ResizeImage(fileName);
                                }
                            
                                fileName = path + "\\detail_view" + (i - m_StartColumnIndex + 1).ToString() + "_exp.jpg";
                                webClient.DownloadFile(cell, fileName);
                                ResizeImage(fileName);
                            }
                            //catch (Exception ex)
                            //{
                            //    Console.WriteLine(ex.Message);
                            //}
                        }
                    }

                    this.Invoke((Action)delegate
                    {
                        m_ProcessedCount++;
                        float progressPercentage = (float)m_ProcessedCount / (float)m_TotalCount * (float)1000;
                        UpdateProgressBar((int)progressPercentage);
                    });
                });
            });

            m_LogList.Items.Add("Block " + Convert.ToString(j + 1) + " ( " + Convert.ToString(start) + " - " + Convert.ToString(end) + ") : Done.");
        }
        
        private string GenerateFolderTitle(string sku, string name)
        {
            string title = string.Empty;
            title += "LF";
            if (sku.Length > 0)
            {
                int hyphenIndex = sku.IndexOf("-");
                if (hyphenIndex > 0)
                {
                    title += sku.Substring(0, hyphenIndex);
                }
            }

            title += "-";

            if (name.Length > 0)
            {
                name = name.Replace("-----", "-");
                name = name.Replace("----", "-");
                name = name.Replace("---", "-");
                name = name.Replace("--", "-");
                name = name.Replace(" - ", "-");
                name = name.Replace("- ", "-");
                name = name.Replace(" -", "-");
                name = name.Replace(" ", "-");
                StringBuilder stringBuilder = new StringBuilder();
                foreach (char c in name)
                {
                    if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '-')
                    {
                        stringBuilder.Append(c);
                    }
                }
                title += stringBuilder.ToString();
            }

            if (title.Length > 50)
            {
                if (title[50] == '-')
                {
                    title = title.Substring(0, 50);
                }
                else
                {
                    title = title.Substring(0, 50);
                    title = title.Substring(0, title.LastIndexOf("-"));
                }
            }

            return title;

        }
    }
}
