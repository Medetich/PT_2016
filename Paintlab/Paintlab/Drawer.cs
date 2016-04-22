using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paintlab
{
    public enum Tool { Pencil, Rectangle, Circle, Eraser, Line, Triangle, Fill, Trapeze};
    class Drawer
    {
        public Graphics g;
        public Bitmap btm;
        public PictureBox picture;
        public Tool tool;
        public Queue<Point> q = new Queue<Point>(100000);

        public Pen pen;
        public bool started = false;
        public Point prev;
        public GraphicsPath path;
        public int width;
        public bool[,] used=new bool[600,600];
        public int[] dx = { 0, 0, -1, 1 };
        public int[] dy = { -1, 1, 0, 0 };


        public Drawer(PictureBox p)
        {
            this.picture = p;
            btm = new Bitmap(picture.Width, picture.Height);
           
            OpenImage ("");
            pen = new Pen(Color.Red, width);
            picture.Paint += picture_Paint;
        }
        public void picture_Paint(object sender, PaintEventArgs e)
        {
            if(path != null)
            {
                e.Graphics.DrawPath(pen, path);     // graphics в Picture box, не основной
            }
        }
        public void Draw(Point curr)
        {
            switch (tool)
            {
                case Tool.Pencil:
                    g.DrawLine(pen, prev, curr);
                    prev = curr;
                    break;
                case Tool.Rectangle:
                    path = new GraphicsPath();
                    int width = Math.Abs(curr.X - prev.X); 
                    int height = Math.Abs(curr.Y - prev.Y); 
                    int FX = prev.X, FY = prev.Y;  

                    if (curr.X < prev.X) FX = curr.X; 
                    if (curr.Y < prev.Y) FY = curr.Y; 

                    Rectangle r = new Rectangle(FX, FY, width, height);
                    path.AddRectangle(r);
                    break;
                case Tool.Circle:
                    path = new GraphicsPath();
                    path.AddEllipse(new Rectangle(prev.X, prev.Y, curr.X - prev.X, curr.Y - prev.Y));
                    break;
                case Tool.Eraser:
                    g.DrawLine(new Pen(Color.White, 10), prev, curr);
                    prev = curr;
                    break;
                case Tool.Line:
                    path = new GraphicsPath();
                    path.AddLine(prev, curr);
                    break;
                case Tool.Trapeze:
                    path = new GraphicsPath();
                    Point po1 = new Point(), po2 = new Point(), po3 = new Point(), po4 = new Point();
                    po1.X = prev.X;
                    po1.Y = prev.Y;
                    po2.X = curr.X - 20;
                    po2.Y = prev.Y;
                    po3.X = curr.X;
                    po3.Y = curr.Y;
                    po4.X = prev.X ;
                    po4.Y = curr.Y;
                    Point[] poins = { po1,po2,po3,po4};
                    path.AddPolygon(poins);
                    break;
                case Tool.Triangle:
                    path = new GraphicsPath();
                    Point p1 = new Point(), p2 = new Point(), p3 = new Point(); 

                    p1.X = prev.X;
                    p1.Y = prev.Y;

                    p2.X = curr.X;
                    p2.Y = curr.Y;

                    p3.X = curr.X - 2 * (Math.Abs(curr.X - prev.X));
                    p3.Y = curr.Y;

                    Point[] points = { p1, p2, p3 };
                    path.AddPolygon(points);
                    break;
                case Tool.Fill:
                    Color clicked_color = btm.GetPixel(prev.X, prev.Y);
                    q.Enqueue(prev);
                    for (int i = 1; i <= picture.Width; ++i)
                        for (int j = 1; j <= picture.Height; ++j)
                            used[i, j] = false;
                    while(q.Count > 0)
                    {
                        Point v = q.First();
                        q.Dequeue();
                        btm.SetPixel(v.X, v.Y, pen.Color);
                        //btm.SetPixel(prev.X, prev.Y, pen.Color);
                        used[v.X, v.Y] = true;
                        for (int i = 0; i < 4; ++i)
                        {
                            int nextx;
                            nextx = v.X + dx[i];
                            int nexty = v.Y + dy[i];
                            if (nextx >= 1 && nexty >= 1 && nextx < picture.Width && nexty < picture.Height && !used[nextx, nexty] &&
                            btm.GetPixel(nextx, nexty) == clicked_color)
                            {
                                used[nextx, nexty] = true;
                                q.Enqueue(new Point(nextx, nexty));
                            }
                       }
                    }
                    break;
                default:
               
                    break;
            }
            picture.Refresh();
        }
        public void savelast()
        {
            if (path!= null)
            {
                g.DrawPath(pen, path);
                path = null;
            }
        }
        public void SaveImage(string filename)
        {
            btm.Save(filename);
        }
        public void OpenImage(string filename)
        {
            btm = filename == "" ? new Bitmap(picture.Width, picture.Height)
                : new Bitmap(filename);

            /*if (filename == "")
            {
                btm = new Bitmap(picture.Width, picture.Height);
            }
            else {
                btm = new Bitmap(filename);
            }*/
            g = Graphics.FromImage(btm);
            picture.Image = btm;
        }








    }
}
