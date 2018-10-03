using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace Project_01_Sprites
{
    class Background
    {

        private int scene = 1;
        public int Scene
        {
            get { return scene; }
            set { scene = value; }
        }

        private bool visible = true;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        private List<Background> children = new List<Background>();
        public List<Background> Children
        {
            get { return children; }
        }

        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double w;
        public double W
        {
            get { return w; }
            set { w = value; }
        }

        private double h;
        public double H
        {
            get { return h; }
            set { h = value; }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        //constructors
        public Background(Image image, int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.image = image;
        }

        public void DrawBackground(Graphics g)
        {
            g.DrawImage(image, (float)X, (float)(Y), (float)W, (float)H );
        }

        public void Paint(Graphics g, int bg)
        {


            if (!Visible) return;
            if(bg==1 || bg ==2)
            {

                Image = Image.FromFile("West.jpg");
                DrawBackground(g);
            }
            else
            {

                Image = Image.FromFile("Sign.png");
                DrawBackground(g);
            }

            // g.TranslateTransform((float)X, (float)Y);

        }
    }
}
