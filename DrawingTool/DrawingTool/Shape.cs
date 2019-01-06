using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DrawingTool
{
    public class Shape
    {        
        [XmlIgnore] public Color Color = Color.Black;
        public int Thickness = 1;
        public DashStyle DashStyle = DashStyle.Solid;
        public List<Point> Points = new List<Point>();
        public Form1.Lik izabraniLik;

        public int ToArgb
        {
            get { return this.Color.ToArgb(); }
            set { Color = Color.FromArgb(value); }
        }

        public void Draw(Graphics gr)
        {
            using (Pen the_pen = new Pen(Color, Thickness))
            {
                the_pen.DashStyle = DashStyle;
                if (DashStyle == DashStyle.Custom)
                {
                    the_pen.DashPattern = new float[] { 10, 2 };
                }
                switch (izabraniLik)
                {
                    case Form1.Lik.FreeLine:
                        
                        gr.DrawLines(the_pen, Points.ToArray());
                        break;

                    case Form1.Lik.Line:
                        gr.DrawLine(the_pen, Points[0], Points[1]);
                        break;

                    case Form1.Lik.Rectangle:
                        int minx = Math.Min(Points[0].X, Points[1].X);
                        int miny = Math.Min(Points[0].Y, Points[1].Y);
                        int maxx = Math.Max(Points[0].X, Points[1].X);
                        int maxy = Math.Max(Points[0].Y, Points[1].Y);
                        gr.DrawRectangle(the_pen, new Rectangle(minx, miny, maxx-minx, maxy - miny));
                        break;
                    case Form1.Lik.Ellipse:
                        break;
                    case Form1.Lik.Eraser:
                        break;
                    case Form1.Lik.Text:
                        break;
                    case Form1.Lik.Brush:
                        break;
                    case Form1.Lik.Select:
                        break;


                }
                
            }
        }
    }
}
