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
    class Char
    {
        
        private bool visible = true;
        Random nm = new Random();

        public bool AimedOn(float x, float y)
        {
            if (x > X && x < X + scale && y>Y && y<Y + scale)
            {
                return true;
            }
            else return false;

        }

        public void die(bool AimedOn,int ClickX, int ClickY)
        {
            if (AimedOn && visible)
            {
                Image = Image.FromFile("BClay.png");
            }
        }

        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        private List<Char> children = new List<Char>();
        public List<Char> Children
        {
            get { return children; }
        }

        private double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        private double width;
        public double Width //properties
        {
            get { return width; }
            set { width = value; }
        }

        private double height;
        public double Height //properties
        {
            get { return height; }
            set { height = value; }
        }

        private double scale = 1;
        public double Scale
        {
            get { return scale; }
            set { scale = value; }
        }
        private double angle = 0;
        public double Angle
        {
            get { return angle; }
            set { angle = value; }
        }

        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        //constructors
        public Char(Image image, int x, int y, int scale)
        {
            this.image = image;
            this.x = x;
            this.y = y;
            this.scale = scale;

        }

        public void Shift(Char C, int x, int y)
        {
            if(visible)
            {
                this.x++;
                this.y++;
            }
        }

        public void DrawForground(Graphics g)
        {
            if(visible) g.DrawImage(image, (float)(X), (float)(Y), (float)Scale, (float)Scale);
        }

        public void Paint(Graphics g,int bg)
        {
           
            if (bg == 1)
            {
                visible = true;
                DrawForground(g);
            }
            else visible=false;

         //   g.TranslateTransform((float)X, (float)Y);
        }
        


    }

}
