using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictute_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            Object[] fonts = new Object[System.Drawing.FontFamily.Families.Length];
            int i = 0;
            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                fonts[i] = font.Name;
                i++;
            }

            toolStripComboBox1.Items.AddRange(fonts);

            Object[] fontsize = new Object[System.Drawing.FontFamily.Families.Length];
            for (int j=0; j<10;j++)
            {
                fontsize[j] = 2 * j + 8;
               
            }
            toolStripComboBox2.Items.AddRange(fontsize);


        }

                

        

        

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //provjeriti je li vec spremljen, ako ne pozvati save as
            if (false)
            {
                //srediti
            }
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();


           


            dlg.Title = "pb" + this.tabControl1.SelectedTab.TabIndex+"Open Image";
            dlg.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {


                // Create a new Bitmap object from the picture file on disk,
                // and assign that to the PictureBox.Image property
                if (this.tabControl1.SelectedTab.Controls[("pb" + this.tabControl1.SelectedTab.TabIndex).ToString()] is PictureBox)
                {
                    //pb.Image = new Bitmap(dlg.FileName);
                }
                
            }
        }

        private void blankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //otvaram novi tab s praznom povrsinom za crtanje
            TabPage tp = new TabPage();
            PictureBox pb = new PictureBox();
            
            tabControl1.SelectedTab.Controls.Add(pb);
            pb.Dock = DockStyle.Fill;
            this.tabControl1.TabPages.Add(tp);
            
            tp.Location = new System.Drawing.Point(4, 22);
            tp.Name = "tabPage";
            tp.Padding = new System.Windows.Forms.Padding(3);
            tp.Size = new System.Drawing.Size(792, 353);
            tp.TabIndex = tabControl1.TabPages.Count;
            tp.Text = "Untitled" + tabControl1.TabPages.Count;
            tp.UseVisualStyleBackColor = true;
            // pictureBox1.Image = null;
        }

        

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Save an Image File";
            
            

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                //draw 
                //int width = Convert.ToInt32(drawImage.Width);
                //int height = Convert.ToInt32(drawImage.Height);
                //Bitmap bmp = new Bitmap(width, height);
                //drawImage.DrawToBitmap(bmp, new Rectangle(0, 0, width, height);
                //bmp.Save(dialog.FileName, ImageFormat.Jpeg);
                //// Saves the Image via a FileStream created by the OpenFile method.  
                //System.IO.FileStream fs =
                //   (System.IO.FileStream)saveFileDialog1.OpenFile();
                ////Saves the Image in the appropriate ImageFormat based upon the
                //// File type selected in the dialog box.
                //// NOTE that the FilterIndex property is one - based.

                //this.tabControl1.SelectedTab.Text = Path.GetFileName(saveFileDialog1.FileName);
                //switch (saveFileDialog1.FilterIndex)
                //{
                //    case 1:
                //        using (PictureBox pb = (PictureBox)this.tabControl1.SelectedTab.Controls["pb"+ this.tabControl1.SelectedTab.TabIndex])
                //        { pb.Image.Save(fs,
                //              System.Drawing.Imaging.ImageFormat.Jpeg);
                //        }

                //        break;

                //    case 2:
                //      //  this.pictureBox1.Image.Save(fs,
                //       //    System.Drawing.Imaging.ImageFormat.Bmp);
                //        break;

                //    case 3:
                //       // this.pictureBox1.Image.Save(fs,
                //        //   System.Drawing.Imaging.ImageFormat.Gif);
                //        break;
                //}


               // fs.Close();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (true) // srediti
            {
                // Display a MsgBox asking the user to save changes or abort.
                if (MessageBox.Show("Do you want to save changes?", this.Name,
                   MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // Cancel the Closing event from closing the form.
                    e.Cancel = true;
                    saveToolStripMenuItem_Click(sender, e);
                }
            }

            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //promijeniti kursor u olovcicu
            PictureBox bm = (PictureBox)tabControl1.SelectedTab.Controls[0];
            //omiguciti da se pojavi dodatan toolbox za crtanje - boje, debljina linije...pogledati sto jos
        }
    }
}
