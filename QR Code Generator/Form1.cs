using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QR_Code_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button_Encode_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("No text entered!");
                return;
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData data = qrGenerator.CreateQrCode(textBox1.Text, QRCodeGenerator.ECCLevel.Q);
            QRCode QRCode = new QRCode(data);
            Bitmap image = QRCode.GetGraphic(14);
            pictureBox1.Image = image;
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Image Files (*.png)|*.png";
                saveFileDialog.FileName = string.Format("QRCode_");
                saveFileDialog.DefaultExt = ".png";
                saveFileDialog.AddExtension = true;
                saveFileDialog.AutoUpgradeEnabled = true;
                if(saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image.Save(saveFileDialog.FileName);
                }
            }
        }
    }
}
