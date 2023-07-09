using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Threading;

namespace SummerPractice4119 
{
    internal class Rectangle 
    {

        private Graphics panel;
        private int width;
        private Dot centre;
        private int height;
        private int num;

        private System.Windows.Forms.Timer moveTimer;
        public bool moving = false;
        public delegate void Runnin();
        public event Runnin rectangleRun;
        public delegate void Stoppin();
        public event Stoppin rectangleStop;
        Thread moveThread;
        public void rectangleInvokeEvent()
        {
            rectangleRun.Invoke();
        }
        
        public Rectangle(int _x, int _y, Graphics _panel)
        {
            centre = new Dot(_x, _y);
            this.panel = _panel;
            width = 100;
            height = 50;
            num = 1;

            moveTimer = new System.Windows.Forms.Timer();
            moveTimer.Interval = 20;
            
            Show();

        }
        public void RectangleMovingStop()
        {

            moving = false;
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
            SolidBrush b = new SolidBrush(Color.Snow);
            panel.FillRectangle(b, centre.GetX(), centre.GetY(), width, height);

        }
        public void Show()

        {
            SolidBrush b = new SolidBrush(Color.DarkOliveGreen);
            panel.FillRectangle(b, centre.GetX(), centre.GetY(), width, height);

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
