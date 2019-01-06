using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace DrawingTool
{
    public partial class Form1 : Form
    {
        #region za moj min i max
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                const int resizeArea = 10;
                Point cursorPosition = PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                if (cursorPosition.X >= ClientSize.Width - resizeArea && cursorPosition.Y >= ClientSize.Height - resizeArea)
                {
                    m.Result = (IntPtr)17; //HTBOTTOMRIGHT
                    return;
                }
                else if (cursorPosition.X <= resizeArea && cursorPosition.Y >= ClientSize.Height - resizeArea)
                {
                    m.Result = (IntPtr)16; //HTBOTTOMLEFT
                    return;
                }
                else if (cursorPosition.X <= resizeArea)
                {
                    m.Result = (IntPtr)10; //HTLEFT
                    return;
                }
                else if (cursorPosition.X >= ClientSize.Width - resizeArea)
                {
                    m.Result = (IntPtr)11; //HTRIGHT
                    return;
                }
                else if (cursorPosition.Y >= ClientSize.Height - resizeArea)
                {
                    m.Result = (IntPtr)15; //HTBOTTOM
                    return;
                }
            }

            base.WndProc(ref m);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
                this.pictureBox3.Image = global::DrawingTool.Properties.Resources.icons8_minimize_window_16;
            }
                

            else
            {
                this.WindowState = FormWindowState.Normal;
                this.pictureBox3.Image = global::DrawingTool.Properties.Resources.icons8_restore_window_16;
            }
                
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        // Likovi koje nacrtamo, kako bi mogli undo i redo


        #region Undo/Redo
        private Stack<string> Undo = new Stack<string>();
        private Stack<string> Redo = new Stack<string>();

        private string GetSnapshot()
        {
            XmlSerializer xml_serializer =
             new XmlSerializer(Shapes.GetType());
            using (StringWriter stream_writer =
                new StringWriter())
            {
                xml_serializer.Serialize(stream_writer, Shapes);
                return stream_writer.ToString();
            }
        }


        private void SaveSnapshot()
        {
            // Save the snapshot.
            Undo.Push(GetSnapshot());

            // Empty the redo list.
            if (Redo.Count > 0) Redo = new Stack<string>();

            // Enable or disable the Undo and Redo menu items.

        }

        private void RestoreTopUndoItem()
        {
            if (Undo.Count == 0)
            {
                // The undo list is empty. Display a blank drawing.
                Shapes = new List<Shape>();
            }
            else
            {
                // Restore the first serialization from the undo list.
                XmlSerializer xml_serializer =
                    new XmlSerializer(Shapes.GetType());
                using (StringReader string_reader =
                    new StringReader(Undo.Peek()))
                {
                    List<Shape> new_shapes =
                        (List<Shape>)
                            xml_serializer.Deserialize(string_reader);
                    Shapes = new_shapes;
                }
            }
            pictureBox1.Refresh();
        }
        #endregion

        #region dio za oblike koje crtam
        private List<Shape> Shapes = new List<Shape>();



        // Trenutni kik kojeg crtamo
        private Shape NewShape = null;
        private Lik lik = Lik.Line;

        private Color chosencolor = Color.Black;
        private Color chosenfillcolor = Color.AliceBlue;

        public enum Lik
        {
            Line, FreeLine, Rectangle, Ellipse, Text, Eraser, Brush, Select
        }
        public Form1()
        {
            InitializeComponent();
            
           // canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(pictureBox1.BackColor);

            // Draw the Shapes.
            foreach (Shape Shape in Shapes)
            {
                Shape.Draw(e.Graphics);
            }

        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {

                //SaveSnapshot();
                // Create the new Shape.
                NewShape = new Shape();
                Shapes.Add(NewShape);

                // Initialize it and add the first point.
                NewShape.Color = chosencolor;
                NewShape.Thickness = Convert.ToInt32( toolStripComboBox1.Text);
                switch (toolStripComboBox2.Text)
                {
                    case "Solid":
                        NewShape.DashStyle = DashStyle.Solid;
                        break;
                    case "Dash":
                        NewShape.DashStyle = DashStyle.Dash;
                        break;
                    case "Dot":
                        NewShape.DashStyle = DashStyle.Dot;
                        break;
                    case "Custom":
                        NewShape.DashStyle = DashStyle.Custom;
                        break;
                }
                NewShape.Points.Add(e.Location);
                NewShape.izabraniLik = lik;

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            //p1 = new Point(e.X, e.Y);
            //Graphics g = pictureBox1.CreateGraphics();
            

        }

        
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (NewShape == null) return;
            SaveSnapshot();
            // See if the new Shape contains more than 1 point.
            if (NewShape.Points.Count < 2)
            {
                // Remove it.
                Shapes.RemoveAt(Shapes.Count - 1);
            }

            NewShape = null;
            pictureBox1.Refresh();
        }

        

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            //p2 = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    if (NewShape == null) return;
                    switch (NewShape.izabraniLik)
                    {
                        case Lik.Line:
                            if (NewShape.Points.Count == 1)
                                NewShape.Points.Add(e.Location);
                            else
                            {
                                NewShape.Points[1] = e.Location;
                                //RestoreTopUndoItem();
                                pictureBox1.Refresh();
                            }
                                

                            break;
                        case Lik.FreeLine:
                            
                            NewShape.Points.Add(e.Location);
                            pictureBox1.Refresh();
                            break;
                        case Lik.Rectangle:

                            if (NewShape.Points.Count == 1)
                                NewShape.Points.Add(e.Location);
                            else
                            {
                                NewShape.Points[1] = e.Location;
                                //RestoreTopUndoItem();
                                pictureBox1.Refresh();
                            }
                            break;
                    }

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }

        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            //
            this.tabPage1.Text = "Untitled" + tabControl1.TabPages.Count;

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                toolStripComboBox3.Items.Add(font.GetName(1).ToString());
            }
            toolStripComboBox3.Text = "Arial";

            foreach (FontFamily font in System.Drawing.FontFamily.Families)
            {
                toolStripComboBox3.Items.Add(font.GetName(1).ToString());
            }
            toolStripComboBox3.Text = "Arial";
            //line thickness and font size
            Object[] fontsize = new Object[10];
            for (int j = 0; j < 10; j++)
            {
                fontsize[j] = 2 * j + 8;

            }
            toolStripComboBox1.Items.AddRange(fontsize);
            toolStripComboBox4.Items.AddRange(fontsize);
            toolStripComboBox1.Text = 1.ToString();
            toolStripComboBox4.Text = 10.ToString();

            //dash style

            foreach (DashStyle dash in System.Enum.GetValues(typeof(DashStyle)))
            {
                toolStripComboBox2.Items.Add(dash.ToString());
            }
            toolStripComboBox2.Text = "Solid";


            toolStripButton4.BackColor = chosencolor;
            toolStripButton5.BackColor = chosenfillcolor;

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                // Move the most recent change to the redo list.
                Redo.Push(Undo.Pop());

                // Restore the top item in the Undo list.
                RestoreTopUndoItem();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo.Push(Redo.Pop());

            // Restore the top item in the Undo list.
            RestoreTopUndoItem();
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lik = Lik.Line;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            this.toolStripDropDownButton1.Image = item.Image;
            //cursor
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lik = Lik.Rectangle;

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            this.toolStripDropDownButton1.Image = item.Image;
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lik = Lik.Ellipse;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            this.toolStripDropDownButton1.Image = item.Image;
        }

        private void freeLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lik = Lik.FreeLine;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            this.toolStripDropDownButton1.Image = item.Image;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            lik = Lik.Text;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            lik = Lik.Eraser;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lik = Lik.Select;
            

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
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
            {
                this.chosencolor = cd.Color;
                this.toolStripButton4.BackColor = cd.Color;
            }

                
        }

        

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                try
                {

                    // Move the most recent change to the redo list.
                    Redo.Push(Undo.Pop());

                    // Restore the top item in the Undo list.
                    RestoreTopUndoItem();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //fill color
            ColorDialog cd = new ColorDialog();

            // Keeps the user from selecting a custom color.
            cd.AllowFullOpen = true;
            // Allows the user to get help. (The default is false.)

            // Sets the initial color select to the current text color.
            //cd.Color = pen1.Color;

            // Update the text box color if the user clicks OK 
            if (cd.ShowDialog() == DialogResult.OK)
            {
                this.chosenfillcolor = cd.Color;
                this.toolStripButton4.BackColor = cd.Color;
            }

        }

        
    }
}
