using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lec_1_DDA_
{
    public class line
    {
        public float xstart , xend  , ystart , yend;
        
    }
    public partial class Form1 : Form
    {
        int Val1, Val2;
        double R ;
        float X1 ,Y1 , X2 , Y2 ;
        line horizontal = new line();
        line vertical = new line();
        string quadrent = "zero" ;
        Bitmap off;
        Timer tt = new Timer();
        List<DDA> Startpts = new List<DDA>();
        List<DDA> Endpts = new List<DDA>();
        DDA PtSt, PtEnd ;
        bool isTravaling = true;


        public Form1()
        {
            this.MouseDown += new MouseEventHandler(Form1_MouseDown);
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_Paint;
            this.Load += Form1_Load;
            tt.Tick += tt_Tick;
            tt.Start();
        }

        void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int x = this.Width / 2;
            int y = this.Height / 2;

            Val1 = ((e.X - x)*(e.X - x)) + ((e.Y - y)*(e.Y - y)) - (480 * 480);
            Val2 = ((e.X - x) * (e.X - x)) + ((e.Y - y) * (e.Y - y)) - (200 * 200);
            if (Val1 < 0 && Val2 > 0 )
            {
                if (e.Y < this.Height / 2)
                {
                    if (e.X > this.Width / 2)
                    {
                        quadrent = "fourth";
                    }
                    else
                    {
                        quadrent = "third";
                    }
                }
                else
                {
                    if (e.X > this.Width / 2)
                    {
                        quadrent = "first";
                    }
                    else
                    {
                        quadrent = "second";
                    }
                }
                MessageBox.Show(quadrent + " valid");
            }
            
            

        }

        void createballs()
        {
            for (double i = 0; i < 350; i += 90)
            {
                PtSt = new DDA();
                PtEnd = new DDA();
                R = 480;
                PtSt.X = Convert.ToSingle(R * Math.Cos((i * Math.PI / 180)) + this.Width / 2); 
                PtSt.Y = Convert.ToSingle(R * Math.Sin((i * Math.PI / 180)) + this.Height / 2);

                PtEnd.X = Convert.ToSingle(R * Math.Cos((i+90 * Math.PI / 180)) + this.Width / 2);
                PtEnd.Y = Convert.ToSingle(R * Math.Sin((i+90 * Math.PI / 180)) + this.Height / 2);

                PtSt.calc(PtEnd);

                Startpts.Add(PtSt);
                Endpts.Add(PtEnd);

            }
        }
        void tt_Tick(object sender, EventArgs e)
        {

           

            DrawDubb(this.CreateGraphics());
        }

        void makelines()
        {
            vertical.xstart = this.Width / 2;
            vertical.ystart = this.Height / 2 - 480;
            vertical.xend =   this.Width / 2;
            vertical.yend =   this.Height / 2 + 480;

            horizontal.xstart = this.Width / 2 - 480;
            horizontal.ystart = this.Height / 2;
            horizontal.xend = this.Width / 2 + 480;
            horizontal.yend = this.Height / 2 ;

        }

        void Form1_Load(object sender, EventArgs e)
        {
            createballs();
            makelines();
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
            
        }

        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        void DrawScene ( Graphics g)
        {
            g.Clear(Color.White);
            
            g.DrawLine(Pens.Red, vertical.xstart, vertical.ystart, vertical.xend, vertical.yend);
            g.DrawLine(Pens.Red, horizontal.xstart, horizontal.ystart, horizontal.xend, horizontal.yend);

            for (double i = 0; i <= 360; i += 0.1)
            {

                R = 200;
                X1 = Convert.ToSingle(R * Math.Cos((i * Math.PI / 180)) + this.Width / 2);
                Y1 = Convert.ToSingle(R * Math.Sin((i * Math.PI / 180)) + this.Height / 2);
                g.FillEllipse(Brushes.Red, X1, Y1, 3, 3);

                R = 480;
                X2 = Convert.ToSingle(R * Math.Cos((i * Math.PI / 180)) + this.Width / 2);
                Y2 = Convert.ToSingle(R * Math.Sin((i * Math.PI / 180)) + this.Height / 2);
                g.FillEllipse(Brushes.Red, X2, Y2, 3, 3);

                
                
            }
            for (double i = 0; i <= 360; i += 90)
            {

                R = 200;
                X1 = Convert.ToSingle(R * Math.Cos((i * Math.PI / 180)) + this.Width / 2);
                Y1 = Convert.ToSingle(R * Math.Sin((i * Math.PI / 180)) + this.Height / 2);
                g.FillEllipse(Brushes.Blue, X1 - 10, Y1 - 8, 20, 20);

                R = 480;
                X2 = Convert.ToSingle(R * Math.Cos((i * Math.PI / 180)) + this.Width / 2);
                Y2 = Convert.ToSingle(R * Math.Sin((i * Math.PI / 180)) + this.Height / 2);
                g.FillEllipse(Brushes.Blue, X2 - 10, Y2 - 8, 20, 20);


            }

        }

        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
