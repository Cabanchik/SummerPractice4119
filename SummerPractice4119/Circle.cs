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
        private List<Circle> circleList;
        private int num;
        int i;
        private bool moving = false;
        public delegate void Runnin();
        public event Runnin circleRun;
        public delegate void Stoppin();
        public event Stoppin circleStop;
        Thread moveThread;
        public bool Moving { get => moving; set => moving = value; }
        public Circle(int _x, int _y, int _rad, Graphics g, int id)
        {
            centre = new Dot(_x, _y);
            rad = _rad;
            num = 1;
            i = id;
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
        public void circleInvokeEvent(Object myObject, EventArgs myEventArgs)
        {
            circleRun.Invoke();
        }
        public void Move(int dx, int dy)
        {
            while (moving)
            {
                
                if (centre.GetX() + rad == 776 || centre.GetY() + rad == 371 || centre.GetY() + rad == 0 || centre.GetX() + rad == 0)
                {
                    moveThread.Abort();
                    return;
                }

                
                Clear();
                centre.Move(dx, dy);
                Show();
                Thread.Sleep(20);
            }
           

        }
        public void StartOrder()
        {
            moving = true;
            moveThread = new Thread(() => Move(i, i));
            moveThread.Start();
        }
        public void Show()
        {
            SolidBrush b = new SolidBrush(Color.Black);
            g.FillEllipse(b, centre.GetX(), centre.GetY(), 2 * rad, 2 * rad);
        }

        public void Clear()
        {
            SolidBrush b = new SolidBrush(Color.White);
            g.FillEllipse(b, centre.GetX(), centre.GetY(), 2 * rad, 2 * rad);

        }
        public void StopSignal()
        {
            Moving = false;
        }

    }
}
