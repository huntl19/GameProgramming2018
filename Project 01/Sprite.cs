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
    public class Sprite
    {
        private bool visible = true;
        public bool Visible
        {
            get { return visible; }
            set { visible = value; }
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
        public Sprite(Image image, int x, int y)
        {
            this.x = x;
            this.y = y;
            this.image = image;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, (float)(X-25), (float)(Y-25), 50, 50);
        }

        private List<Sprite> children = new List<Sprite>();
        public List<Sprite> Children
        {
            get { return children; }
        }

        public void Paint(Graphics g)
        {
            if (!Visible) return;
            Draw(g);

           // g.TranslateTransform((float)X, (float)Y);
          
            //do nothing for painting myself
            foreach (Sprite child in children)
            {
                child.Paint(g);
            }
        }




    }
}
