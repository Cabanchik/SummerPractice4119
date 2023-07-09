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
    internal class Circle
    {
        private Graphics g;
        private int rad;
        private Dot centre;
        private int speed;
        private List<Circle> circleList;
        private int num;
        private bool moving = false;
        public delegate void Runnin();
        public event Runnin circleRun;
        Thread moveThread;

        public bool Moving { get => moving; set => moving = value; }

        public void circleInvokeEvent(Object myObject, EventArgs myEventArgs)
        {
            circleRun.Invoke();
        }

        public Circle(int _x, int _y, int _rad, Graphics g)
        {
            centre = new Dot(_x, _y);
            rad = _rad;
            num = 1;
            circleRun += StartOrder;
            this.g = g;
            Show();

        }

        public int getCircleX()

        {
            return centre.GetX();
        }

        public int getCircleY()

        {
            return centre.GetY();
        }

        public void Move(int dx, int dy)
        {
           
                Clear();
                centre.Move(dx, dy);
                Show();
                if (centre.GetX() + rad == 776 || centre.GetY() + rad == 371 || centre.GetY() + rad == 0 || centre.GetX() + rad == 0)
                {
                    Moving = false;
                }
            
        }
        public void StartOrder()
        {
            moving = true;

            moveThread = new Thread(() => Move(1, 0));
            moveThread.Start();
        }
        public void Show()

        {
            SolidBrush b = new SolidBrush(Color.Black);
            g.FillEllipse(b, centre.GetX(), centre.GetY(), 2 * rad, 2 * rad);

        }

        public void Clear()

        {
            SolidBrush b = new SolidBrush(Color.Snow);
            g.FillEllipse(b, centre.GetX(), centre.GetY(), 2 * rad, 2 * rad);

        }



        public void MoveTimerEventX(Object myObject, EventArgs myEventArgs)
        {
            if (Moving == true)
            {
                Move(1, 1);
            }
            else
            {
                return;
            }
            
        }

        public void MoveTimerEventY(Object myObject, EventArgs myEventArgs)
        {

            if (Moving == true)
            {
                Move(-1, -1);
            }
            else
            {
                return;
            }

        }
        public void StopSignal()
        {
            Moving = false;
        }

    }
}
