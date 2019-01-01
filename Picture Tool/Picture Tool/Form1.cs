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
        Point p1;
        Point p2;
        Graphics g;
        private Bitmap bmp;
        Pen pen1;
        
        Lik izabraniLik;
        bool crtam = false;

        public enum Lik // sto sve crtam
        {
            Line, FreeLine, Rectangle, Ellipse, Text, Eraser, Brush
        }
        
        public Form1()
        {
            p1 = new Point();
            p2 = new Point();
            pen1 = new Pen(Color.Black, 3);
            InitializeComponent();

            


        }

                

        
        private void Form1_Load(object sender, EventArgs e)
        {
            // punim combobox sa fontovima
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage" + tabControl1.TabPages.Count; 
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(914, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Untitled" + tabControl1.TabPages.Count; 
            this.tabPage1.UseVisualStyleBackColor = true;
            // 

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(font.GetName(1).ToString());
            }

            

            Object[] fontsize = new Object[10];
            for (int j = 0; j < 10; j++)
            {
                fontsize[j] = 2 * j + 8;

            }
            toolStripComboBox2.Items.AddRange(fontsize);

            toolStripComboBox3.Text = 10.ToString();


            //nova bitmapa na koju cemo crtati
            bmp = new Bitmap(this.tabPage1.Width, this.tabPage1.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics.FromImage(bmp).Clear(Color.White);
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
            this.tabControl1.TabPages.Add(tp);        
            
            
            tp.Location = new System.Drawing.Point(4, 22);
            tp.Name = "tabPage" + tabControl1.TabPages.Count; 
            tp.Padding = new System.Windows.Forms.Padding(3);
            tp.Size = new System.Drawing.Size(792, 353);
            tp.TabIndex = tabControl1.TabPages.Count;
            tp.Text = "Untitled" + tabControl1.TabPages.Count;
            tp.UseVisualStyleBackColor = true;

            tp.Controls.Add(pb);
            pb.Dock = DockStyle.Fill;
            pb.BackColor = Color.Transparent;

            tabControl1.SelectedTab = tp;

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
                
                
               
                //// Saves the Image via a FileStream created by the OpenFile method.  
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                ////Saves the Image in the appropriate ImageFormat based upon the
                //// File type selected in the dialog box.
                //// NOTE that the FilterIndex property is one - based.
                //bmp.Save("a.bmp", ImageFormat.Bmp);
                this.tabControl1.SelectedTab.Text = Path.GetFileName(saveFileDialog1.FileName);
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                     //   bmp.Save(fs,
                     //         System.Drawing.Imaging.ImageFormat.Jpeg);
                        

                        break;

                    case 2:
                      //  bmp.Save(fs,
                      //     System.Drawing.Imaging.ImageFormat.Bmp);
                        break;

                    case 3:
                       // bmp.Save(fs,
                       //    System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }


                fs.Close();
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

      


        private void Tab_MouseDown(object sender, MouseEventArgs me)
        {
            //g = this.tabControl1.SelectedTab.CreateGraphics();
            p1.X = me.X;
            p1.Y = me.Y;
            crtam = true;
            switch (izabraniLik)
            {
                case Lik.Line:
                    this.tabControl1.SelectedTab.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
                    break;
                case Lik.Brush:
                    
                    break;
                case Lik.FreeLine:
                    //g = this.tabControl1.SelectedTab.CreateGraphics();
                    break;

            }
            

            //this.tabControl1.SelectedTab.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            
            

        }

        private void Tab_MouseMove(object sender, MouseEventArgs me)
        {

            

            Graphics g = this.tabControl1.SelectedTab.Controls[0].CreateGraphics();
            if (me.Button == MouseButtons.Left)
            {
                switch (izabraniLik)
                {
                    case Lik.Line:

                        {


                            this.tabControl1.SelectedTab.Refresh();
                            //this.tabControl1.SelectedTab.Invalidate();//new Rectangle(p1.X, p1.Y, p2.X - p1.X, p2.Y - p1.Y)
                        }
                        break;
                    case Lik.Brush:
                        
                        g.FillEllipse(new SolidBrush(pen1.Color), me.X, me.Y, Convert.ToInt32(this.toolStripComboBox3.Text), Convert.ToInt32(this.toolStripComboBox3.Text));
                                                
                        break;
                    case Lik.FreeLine:
                        
                            g.DrawLine(pen1, p1, new Point(me.X, me.Y));
                        p1.X = me.X;
                        p1.Y = me.Y;
                        break;

                }

                p2.X = me.X;
                p2.Y = me.Y;
            }

            g.Dispose();

        }

        private void Tab_MouseUp(object sender, MouseEventArgs me)
        {
            switch (izabraniLik)
            {
                case Lik.FreeLine:

                    crtam = false;

                    break;
                
            }

            //this.tabControl1.SelectedTab.Invalidate(new Rectangle(p1.X, p1.Y, p2.X-p1.X, p2.Y - p1.Y));
            //this.tabControl1.SelectedTab.Paint -= this.Form1_Paint;


        }
        private void Form1_Paint(object sender, PaintEventArgs pe)
        {
            // Declares the Graphics object and sets it to the Graphics object  
            // supplied in the PaintEventArgs.  
            Graphics g = pe.Graphics;
            
            // Insert code to paint the form here. 
            g.DrawLine(pen1, p1, p2);

            //g.Dispose();

        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            //border color
            ColorDialog cd = new ColorDialog();
            
            // Keeps the user from selecting a custom color.
            cd.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)
            
            // Sets the initial color select to the current text color.
            //cd.Color = pen1.Color;

            // Update the text box color if the user clicks OK 
            if (cd.ShowDialog() == DialogResult.OK)
                
               this.pen1.Color = cd.Color;
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            //fill
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            //ne znam jos
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            
            this.tabControl1.SelectedTab.Cursor = System.Windows.Forms.Cursors.Cross;

            izabraniLik = Lik.Line;
            // sto ako izaberem, pa promijenim tab - srediti
            this.tabControl1.SelectedTab.Controls[0].MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseDown);
            this.tabControl1.SelectedTab.Controls[0].MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseUp);
            this.tabControl1.SelectedTab.Controls[0].MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseMove);
        }

        private void freeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //promijeniti kursor u olovcicu
            this.tabControl1.SelectedTab.Cursor = System.Windows.Forms.Cursors.Cross;

            izabraniLik = Lik.FreeLine;

            this.tabControl1.SelectedTab.Controls[0].MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseDown);
            this.tabControl1.SelectedTab.Controls[0].MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseUp);
            this.tabControl1.SelectedTab.Controls[0].MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseMove);
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab.Cursor = System.Windows.Forms.Cursors.Cross;

            izabraniLik = Lik.Rectangle;

            this.tabControl1.SelectedTab.Controls[0].MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseDown);
            this.tabControl1.SelectedTab.Controls[0].MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseUp);
            this.tabControl1.SelectedTab.Controls[0].MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseMove);
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab.Cursor = System.Windows.Forms.Cursors.Cross;

            izabraniLik = Lik.Ellipse;

            this.tabControl1.SelectedTab.Controls[0].MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseDown);
            this.tabControl1.SelectedTab.Controls[0].MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseUp);
            this.tabControl1.SelectedTab.Controls[0].MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseMove);
        }

        private void brushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab.Cursor = System.Windows.Forms.Cursors.Cross;

            izabraniLik = Lik.Brush;

            this.tabControl1.SelectedTab.Controls[0].MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseDown);
            this.tabControl1.SelectedTab.Controls[0].MouseUp += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseUp);
            this.tabControl1.SelectedTab.Controls[0].MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tab_MouseMove);
        }







        //  private PictureBox pictureBox1 = new PictureBox();
        // Cache font instead of recreating font objects each time we paint.
        //  private Font fnt = new Font("Arial", 10);
        //private void Form1_Load(object sender, System.EventArgs e)
        //{
        //    // Dock the PictureBox to the form and set its background to white.
        //    pictureBox1.Dock = DockStyle.Fill;
        //    pictureBox1.BackColor = Color.White;
        //    // Connect the Paint event of the PictureBox to the event handler method.
        //    pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);

        //    // Add the PictureBox control to the Form.
        //    this.Controls.Add(pictureBox1);
        //}

        //private void pictureBox1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        //{
        //    // Create a local version of the graphics object for the PictureBox.
        //    Graphics g = e.Graphics;

        //    // Draw a string on the PictureBox.
        //    g.DrawString("This is a diagonal line drawn on the control",
        //        fnt, System.Drawing.Brushes.Blue, new Point(30, 30));
        //    // Draw a line in the PictureBox.
        //    g.DrawLine(System.Drawing.Pens.Red, pictureBox1.Left, pictureBox1.Top,
        //        pictureBox1.Right, pictureBox1.Bottom);
        //}


    }
}
