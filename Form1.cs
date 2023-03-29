using System.Windows.Forms.Design;

namespace Ascii_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //Open file using menu
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //open image in picture box
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap image1 = new Bitmap(openFileDialog1.FileName);
                    pictureBox1.Image = image1;

                }
                catch (Exception error)
                {
                    //error message when it's not an image
                    MessageBox.Show("Error. Please choose an IMAGE file." , error.Message , MessageBoxButtons.OKCancel , MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //use button to reveal Ascii image
            BitmapAscii ascii = new BitmapAscii((int)numericUpDown1.Value, (int)numericUpDown2.Value);
            Bitmap image1 = new Bitmap(openFileDialog1.FileName);
            richTextBox1.Text = ascii.Asciitize(image1);
        }
    }
}