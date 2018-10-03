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
    class Buttons
    {

        public bool AimedOn(float x, float y)
        {
            if (x > X && x < X + 200 && y > Y && y < Y + 100)
            {
                return true;
            }
            else return false;

        }


        private bool visible = true;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
        }

        private List<Buttons> children = new List<Buttons>();
        public List<Buttons> Children
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

        private Image image;
        public Image Image
        {
            get { return image; }
            set { image = value; }
        }

        //constructors
        public Buttons(Image image, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.image = image;
        }
        public int die(bool AimedOn, int ClickX, int ClickY, int bg)
        {
            if (AimedOn && visible)
            {
                return 1;
            }
            else return bg;
        }
        public void DrawMidground(Graphics g)
        {
            g.DrawImage(image, (float)(X), (float)(Y), 200, 100);
        }
        public void Paint(Graphics g,int bg)
        {
            if (!Visible) return;
            if (bg == 3)
            {
                Image = Image.FromFile("Start.png");
                DrawMidground(g);
            }
            if (bg == 2)
            {
                Image = Image.FromFile("Resume.png");
                DrawMidground(g);
            }
            else
            {
                //Visible = false;
            }
        }
        public Buttons setButtons(int clientSizeX, int clientSizeY, int bg)
        {
            Buttons butts = new Buttons(Image, clientSizeX / 2 - 100, (clientSizeY / 4));
            return butts;
        }
    }
}
