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
    public partial class Engine : Form
    {
        public int clickX = 0;
        public int clickY = 0;
        public int clientSizeX = 0;
        public int clientSizeY = 0;
        static Sprite s = new Sprite(Image.FromFile("Cross1.png"), 0, 0);
        static Background b = new Background(null, 0, 0, 0, 0);
        static Buttons butts = new Buttons(null, 0, 0);
        static Char clay = new Char(Image.FromFile("Clay.png"), 0, 0, 20);
        public int bg = 3;
        public bool mouseDown = false;
        public int[] isBroke = new int[10];
        List<Buttons> buttons = new List<Buttons>();


        public int ClickX
        {
            get { return clickX; }
        }
        public int ClickY
        {
            get { return clickY; }
        }


        public Engine()
        {


            InitializeComponent();
            DoubleBuffered = true;
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 33;
            t.Tick += T_Tick;
            t.Start();
         
        }


        private void T_Tick(object sender, EventArgs e)
        {
            clay.Shift(clay,(int)clay.X,(int)clay.Y);
            this.Refresh();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            clay.Shift(clay, (int)clay.X, (int)clay.Y);
            s.X = e.X;
            s.Y = e.Y;
            Refresh();
        }
        
        public void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
            mouseDown = true;
            clickX = e.X;
            clickY = e.Y;
            if (butts.AimedOn((float)s.X, (float)s.Y)) bg = 1;
            clay.die(clay.AimedOn(clickX, clickY), ClickX, clickY);
            bg=butts.die(clay.AimedOn(clickX, clickY), clickX, clickY,bg);


        }
        private void Engine_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            clientSizeX = ClientSize.Width;
            clientSizeY = ClientSize.Height;
            b = new Background(b.Image, 0, 0, clientSizeX, clientSizeY);
            butts = new Buttons(butts.Image, clientSizeX / 2 - 100, (clientSizeY / 4));
            b.Paint(e.Graphics,bg);
            clay.Paint(e.Graphics,bg);
            butts.Paint(e.Graphics,bg);
            s.Paint(e.Graphics);

        }

        private void Engine_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (bg == 1)bg = 3;
            Refresh();
        }

        private void Engine_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
