using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labaoop4_1
{
    
    public partial class Form1 : Form
    {
        private List<CCircle> FCircles = new List<CCircle>();
        private int ctrl = 0;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (CCircle Circle in FCircles)
            {
                Circle.drawCircle(e.Graphics);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ctrl == 0)
            {
                foreach (CCircle Circle1 in FCircles)
                {
                    Circle1.setColor("Black");
                }
                CCircle Circle = new CCircle(e.X, e.Y, 20);
                FCircles.Add(Circle);
            }
            if (ctrl == 1)
            {
                foreach (CCircle Circle1 in FCircles)
                {
                    if (Circle1.checkCircle(e) == true && checkBox2.Checked==true)
                    {
                        break;
                    }
                }
                Refresh();
            }
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < FCircles.Count(); i++)
            {
                if (FCircles[i].getColor() == "Red")
                {
                    FCircles.RemoveAt(i);
                    i--;
                }
            }
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ModifierKeys==Keys.Control)
            {
                checkBox1.Checked = !checkBox1.Checked;
            }
            switch (ctrl)
            {
                case 0:
                    ctrl++;
                    foreach (CCircle Circle1 in FCircles)
                    {
                        Circle1.setCtrl(true);
                    }
                    break;
                case 1:
                    ctrl = 0;
                    foreach (CCircle Circle1 in FCircles)
                    {
                        Circle1.setCtrl(false);
                    }
                    break;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
           
        }
    }
    public class CCircle
    {
        private int x, y, rad;
        private string color = "Red";
        private bool ctrl=false;
        public CCircle(int xp, int yp, int radp)
        {
            x = xp;
            y = yp;
            rad = radp;

        }
        public void drawCircle(Graphics Canvas)
        {
            if (color == "Red")
            {
                Canvas.DrawEllipse(new Pen(Color.Red), x - rad, y - rad, rad * 2, rad * 2);
            }
            else
            {
                Canvas.DrawEllipse(new Pen(Color.Black), x - rad, y - rad, rad * 2, rad * 2);
            }
        }
        public void setColor(string Color)
        {
            color = Color;
        }
        public string getColor()
        {
            return color;
        }
       public bool checkCircle(MouseEventArgs e)
        {
            if (ctrl) {
                if (Math.Pow(e.X - x, 2) + Math.Pow(e.Y - y, 2) <= Math.Pow(rad, 2) && color!="Red")
                {
                    color = "Red";
                    return true;
                }
            }
            return false;
        }
        public void setCtrl(bool a)
        {
            ctrl = a;
        }
        
    }
}
