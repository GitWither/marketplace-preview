using MarketplacePreview.Properties;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MarketplacePreview
{
    public partial class Window : Form
    {
        public Window()
        {
            InitializeComponent();
        }

        private void LoadPreview(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(Resources.MainPanel);
            Graphics graphics = Graphics.FromImage(image);
            StringFormat far = new StringFormat
            {
                Alignment = StringAlignment.Far
            };
            StringFormat near = new StringFormat
            {
                Alignment = StringAlignment.Near
            };
            try
            {
                Bitmap thumbnail = new Bitmap(Image.FromFile(thumbnailPath.Text), new Size(301, 170));
                graphics.DrawImage(thumbnail, new Point(2, 2));
                graphics.DrawString(price.Text, new Font("Segoe WP", 12), Brushes.Yellow, 275, 217, far);
                graphics.DrawString(author.Text, new Font("Segoe WP", 12), Brushes.DarkGray, 25, 195, near);
                graphics.DrawString(rating.Text, new Font("Segoe WP Semibold", 11), Brushes.White, 30, 217, far);
                graphics.DrawString(title.Text, new Font("Segoe WP", 12), Brushes.White, 3, 175, near);
                pictureResult.Image = image;
                saveButton.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Save(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Image File | *.png";
            if (dialog.ShowDialog() == DialogResult.OK)
                pictureResult.Image.Save(dialog.FileName, ImageFormat.Png);
        }

        private void SelectThumbnail(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Title = "Select Thumbnail",
                Filter = "Image Files (*.png) | *.png"
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                thumbnailPath.Text = fileDialog.FileName;
            }
        }
    }
}
