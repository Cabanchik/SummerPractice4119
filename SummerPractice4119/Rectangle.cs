using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace SummerPractice4119 
{
    internal class Rectangle 
    {

        private Panel panel;
        private int width;
        private Dot centre;
        private int height;
        private int num;

        private Timer moveTimer;
        public bool moving = false;

        public Rectangle(int _x, int _y, Panel _panel)
        {
            centre = new Dot(_x, _y);
            panel = _panel;
            width = 100;
            height = 50;
            num = 1;

            moveTimer = new Timer();
            moveTimer.Interval = 20;
            
            Show();

        }
        public bool RectangleMovingStop()
        {

            moving = false;
            return moving;
        }
        public void Move(int dx, int dy)
        {
            if (moving == true)
            {
                if (getRectangleX() <= 330 || getRectangleY() <= 170)
                {
                   
                    Clear();
                    centre.Move(dx, dy);
                    Show();
                    
                }
                else
                {
                    RectangleMovingStop();
                }
                

            }


        }
        public void Clear()

        {
            SolidBrush b = new SolidBrush(panel.BackColor);
            panel.CreateGraphics().FillRectangle(b, centre.GetX(), centre.GetY(), width, height);

        }
        public void Show()

        {
            SolidBrush b = new SolidBrush(Color.DarkOliveGreen);
            panel.CreateGraphics().FillRectangle(b, centre.GetX(), centre.GetY(), width, height);

        }
        public int getRectangleX()

        {
            return centre.GetX();
        }

        public int getRectangleY()

        {
            return centre.GetY();
        }
        public void MoveTimerEventX(Object myObject, EventArgs myEventArgs)
        {

            Move(1, 1);

        }


    }

 
}
