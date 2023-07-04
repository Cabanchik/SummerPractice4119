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
    internal class Circle
    {
        private Panel panel;
        private int rad;
        private Dot centre;
        private int speed;
        private List<Circle> circleList;
        private int num;
        public bool moving = false;
   

        public Circle(int _x, int _y, int _rad, Panel _panel)
        {
            centre = new Dot(_x, _y);
            panel = _panel;
            speed = 1;
            rad = _rad;
            num = 1;

            
            Show();

        }

        public Circle(int _x, int _y, int _rad, int _speed, int _num, Panel _panel, List<Circle> _list)
        {
            centre = new Dot(_x, _y);
            panel = _panel;
            speed = _speed;
            rad = _rad;
            num = _num;
                       
            Show();
            if (num < 4)
            {
                SolidBrush b = new SolidBrush(Color.Indigo);
                panel.CreateGraphics().FillEllipse(b, centre.GetX(), centre.GetY(), 2 * rad, 2 * rad);
            }
            else
            {
                circleList.Add(this);
                foreach (Circle circle in circleList)
                {
                    SetList(circleList);
                }
                
            }
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
            if (moving == true)
            {
                Clear();
                centre.Move(dx, dy);
                Show();
                if (getCircleX() + 2 * rad == panel.Width || getCircleY() + 2 * rad == panel.Height || getCircleX() + 2 * rad == 0 || getCircleY() + 2 * rad == 0)
                {
                    StopSignal();
                }
            }
            
            
        }

        public void Show()

        {
            SolidBrush b = new SolidBrush(Color.Indigo);
            panel.CreateGraphics().FillEllipse(b, centre.GetX(), centre.GetY(), 2 * rad, 2 * rad);

        }

        public void Clear()

        {
            SolidBrush b = new SolidBrush(panel.BackColor);
            panel.CreateGraphics().FillEllipse(b, centre.GetX(), centre.GetY(), 2 * rad, 2 * rad);

        }

        private void SpawnTimerEvent(Object myObject, EventArgs myEventArgs)
        {
            circleList.Add(new Circle(getCircleX(), getCircleY() - 50, rad, speed + 1, num + 1, panel, circleList));

        }

        public void MoveTimerEventX(Object myObject, EventArgs myEventArgs)
        {

            Move(1, 1);

        }
        public void MoveTimerEventY(Object myObject, EventArgs myEventArgs)
        {

            Move(-1, -1);

        }

       

       

        public void StopSignal()
        {
            moving = false;
        }

        

        public void Destroy()
        {
            for (int i = 4; i >= 0; i--)
            {
                circleList[i].Clear();
                circleList[i] = null;
            }
        }

        public void SetList(List<Circle> _list)
        {
            circleList = _list;
        }
    }
}
