﻿using System;
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

        private void Form1_Paint(object sender, PaintEventArgs e)//описание события Paint
        {
            foreach (CCircle Circle in FCircles)
            {
                Circle.drawCircle(e.Graphics);//Рисует все круги из списка
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)//описание события нажатия мыши
        {
            if (ctrl == 0)//не нажат ctrl
            {
                foreach (CCircle Circle1 in FCircles)
                {
                    Circle1.setColor("Black");//снимает выделение со всех объектов
                }
                CCircle Circle = new CCircle(e.X, e.Y, 20);//создает новый объект с выделением
                FCircles.Add(Circle);
            }
            if (ctrl == 1)//нажат ctrl
            {
                foreach (CCircle Circle1 in FCircles)
                {
                    if (Circle1.checkCircle(e) == true && checkBox2.Checked==true)//проверка на массовое выделение
                    {
                        break;
                    }
                }
                Refresh();
            }
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)//описание события нажатия на кнопку Delete
        {
            for(int i = 0; i < FCircles.Count(); i++)
            {
                if (FCircles[i].getColor() == "Red")//проверка выделения объектов
                {
                    FCircles.RemoveAt(i);//удаление выделенных объектов
                    i--;
                }
            }
            Refresh();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)//описание события нажатия клавиши на клавиатуре
        {
            if (ModifierKeys==Keys.Control)//если нажатая клавиша Control
            {
                checkBox1.Checked = !checkBox1.Checked;//устанавливает флаг в чекбокс в определенное значение
            }
            switch (ctrl)//в зависимости от состояния флага
            {
                case 0:
                    ctrl++;
                    foreach (CCircle Circle1 in FCircles)
                    {
                        Circle1.setCtrl(true);//если нажат Control устанавливает определенное значение
                    }
                    break;
                case 1:
                    ctrl = 0;
                    foreach (CCircle Circle1 in FCircles)
                    {
                        Circle1.setCtrl(false);//если отжат Control устанавливает определенное значение
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
    public class CCircle//описание объекта круга
    {
        private int x, y, rad;//координаты и радиус
        private string color = "Red";//цвет выделения(изначальный)
        private bool ctrl=false;
        public CCircle(int xp, int yp, int radp)//конструктор с параметрами
        {
            x = xp;
            y = yp;
            rad = radp;

        }
        public void drawCircle(Graphics Canvas)//метод отрисовки круга
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
        public void setColor(string Color)//сеттер цвета круга
        {
            color = Color;
        }
        public string getColor()//геттер цвета круга
        {
            return color;
        }
       public bool checkCircle(MouseEventArgs e)//проверка на попадание курсора мыши во внутрь круга
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
        public void setCtrl(bool a)//сеттер флага выделения
        {
            ctrl = a;
        }
        
    }
}
