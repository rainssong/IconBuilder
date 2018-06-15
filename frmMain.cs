using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace IconBuilder
{
    public partial class FrmMain : Form
    {
        string path = "";
        string iosPath = "";
        string androidPath = "";
        string desktopPath = "";
        public FrmMain()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 获取等比例缩放图片的方法
        /// </summary>
        /// <param name="imgPath">待缩放图片路径</param>
        /// <param name="savePath">缩放图片保存路径</param>
        /// <param name="format">缩放图片保存的格式</param>
        /// <param name="scaling">要保持的宽度或高度</param>
        /// <returns></returns>
        public bool GetThumbnail(string imgPath, string savePath, ImageFormat format, int scaling)
        {
            try
            {
                using (Bitmap myBitmap = new Bitmap(imgPath))
                {
                    using (Image myThumbnail = myBitmap.GetThumbnailImage(scaling, scaling, () => { return false; }, IntPtr.Zero))
                    {
                        myThumbnail.Save(savePath, format);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PNG/JPG/BMP Image|*.png;*.jpg;*.bmp";
            openFileDialog1.Title = "打开";
            openFileDialog1.Multiselect = false;
            openFileDialog1.CheckFileExists = false;
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.ShowDialog();
            txtPath.Text = openFileDialog1.FileName;
            path = openFileDialog1.FileName.Substring(0, openFileDialog1.FileName.Length - openFileDialog1.SafeFileName.Length);
            path = path + DateTime.Now.ToString("yyyyMMddhhmmss") + "\\";
            iosPath = path + "ios\\";
            androidPath = path + "android\\";
            desktopPath = path + "desktop\\";
            //path = path + DateTime.Now.ToString("yyyyMMddhhmmss") + "\\";
            //txtPath.Text = path;
        }

        private void btnBuilder_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Equals("") || path.Equals(""))
                return;
            if (Directory.CreateDirectory(iosPath) != null && Directory.CreateDirectory(androidPath) != null && Directory.CreateDirectory(desktopPath) != null)
            {
                bool flag = true;
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "iTunesArtwork.png", ImageFormat.Png, 512);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "iTunesArtwork@2x.png", ImageFormat.Png, 1024);//iTunesArtwork
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-60@3x.png", ImageFormat.Png, 180);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-167.png", ImageFormat.Png, 167);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-76@2x.png", ImageFormat.Png, 152);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-72@2x.png", ImageFormat.Png, 144);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-120.png", ImageFormat.Png, 120);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-57@2x.png", ImageFormat.Png, 114);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-50@2x.png", ImageFormat.Png, 100);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-40@2x.png", ImageFormat.Png, 80);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-76.png", ImageFormat.Png, 76);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-72.png", ImageFormat.Png, 72);
                //flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-60.png", ImageFormat.Png, 60);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-29@2x.png", ImageFormat.Png, 58);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-57.png", ImageFormat.Png, 57);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-50.png", ImageFormat.Png, 50);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-40.png", ImageFormat.Png, 40);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon-29.png", ImageFormat.Png, 29);

                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-24.png", ImageFormat.Png, 24);
                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-32.png", ImageFormat.Png, 32);
                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-36.png", ImageFormat.Png, 36);
                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-48.png", ImageFormat.Png, 48);
                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-72.png", ImageFormat.Png, 72);

                flag = flag && GetThumbnail(txtPath.Text, desktopPath + "Icon-16.png", ImageFormat.Png, 16);
                flag = flag && GetThumbnail(txtPath.Text, desktopPath + "Icon-32.png", ImageFormat.Png, 32);
                flag = flag && GetThumbnail(txtPath.Text, desktopPath + "Icon-48.png", ImageFormat.Png, 48);
                flag = flag && GetThumbnail(txtPath.Text, desktopPath + "Icon-128.png", ImageFormat.Png, 128);


                if (flag)
                {
                    MessageBox.Show("ICON生成完毕！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start("Explorer.exe", path);
                }
                else
                {
                    MessageBox.Show("出错啦！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPath.Text.Equals("") || path.Equals(""))
                return;
            if (Directory.CreateDirectory(iosPath) != null && Directory.CreateDirectory(androidPath) != null && Directory.CreateDirectory(desktopPath) != null)
            {
                bool flag = true;
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "Icon@2x.png", ImageFormat.Png, 120);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon24x24@2x.png", ImageFormat.Png, 48);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon27.5@2x.png", ImageFormat.Png, 55);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon29x29@2x.png", ImageFormat.Png, 58);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon29x29@3x.png", ImageFormat.Png, 87);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon40x40@2x.png", ImageFormat.Png, 80);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon44x44@2x.png", ImageFormat.Png, 88);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon57x57.png", ImageFormat.Png, 57);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon57x57@2x.png", ImageFormat.Png, 114);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon60x60@2x.png", ImageFormat.Png, 120);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon60x60@3x.png", ImageFormat.Png, 180);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon72x72@2x~ipad.png", ImageFormat.Png, 144);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon72x72~ipad.png", ImageFormat.Png, 72);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon76x76@2x~ipad.png", ImageFormat.Png, 152);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon76x76~ipad.png", ImageFormat.Png, 76);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon86x86@2x.png", ImageFormat.Png, 172);
                flag = flag && GetThumbnail(txtPath.Text, iosPath + "AppIcon98x98@2x.png", ImageFormat.Png, 196);

                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-24.png", ImageFormat.Png, 24);
                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-32.png", ImageFormat.Png, 32);
                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-36.png", ImageFormat.Png, 36);
                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-48.png", ImageFormat.Png, 48);
                flag = flag && GetThumbnail(txtPath.Text, androidPath + "Icon-72.png", ImageFormat.Png, 72);

                flag = flag && GetThumbnail(txtPath.Text, desktopPath + "Icon-16.png", ImageFormat.Png, 16);
                flag = flag && GetThumbnail(txtPath.Text, desktopPath + "Icon-32.png", ImageFormat.Png, 32);
                flag = flag && GetThumbnail(txtPath.Text, desktopPath + "Icon-48.png", ImageFormat.Png, 48);
                flag = flag && GetThumbnail(txtPath.Text, desktopPath + "Icon-128.png", ImageFormat.Png, 128);


                if (flag)
                {
                    MessageBox.Show("ICON生成完毕！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    System.Diagnostics.Process.Start("Explorer.exe", path);
                }
                else
                {
                    MessageBox.Show("出错啦！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
