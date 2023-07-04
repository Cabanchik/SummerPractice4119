using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SummerPractice4119
{
    public partial class Form1 : Form
    {
        Circle circle;
        Circle circle1;
        Circle circle2;
        Rectangle sas;
        Circle circle3;
        bool started = false;
        private Timer moveTimer;
        public Timer rectangleTimer;

        public Form1()
        {

            InitializeComponent();

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!started)
            {

                sas = new Rectangle(250, 70, panelMain);
                sas.moving = true;
                circle.moving = true;
                circle1.moving = true;
                circle2.moving = true;
                circle3.moving = true;
                moveTimer = new Timer();
                moveTimer.Interval = 5000;
                rectangleTimer = new Timer();
                rectangleTimer.Interval = 20;
                rectangleTimer.Tick += sas.MoveTimerEventX;
                moveTimer.Tick += new EventHandler(Timer_Tick);
                rectangleTimer.Start();
                moveTimer.Start();
                started = true;

            }
        }

        public void Timer_Tick(object sender, EventArgs e)
        {
            moveTimer.Tick += circle.MoveTimerEventX;
            moveTimer.Tick += circle1.MoveTimerEventX;
            moveTimer.Tick += circle2.MoveTimerEventY;
            moveTimer.Tick += circle3.MoveTimerEventY;
           
        }
        private void onloaded(object sender, EventArgs e)
        {
            if (!started)
            {
                started = true;

            }
        }
        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (started)
            {
                circle.Destroy();
                circle = null;
            }
            started = false;
        }


        private void panelMain_Click(object sender, EventArgs e)
        {
            circle = new Circle(600, 100, 20, panelMain);

            circle1 = new Circle(500, 250, 20, panelMain);
            circle2 = new Circle(200, 50, 20, panelMain);
            circle3 = new Circle(20, 250, 20, panelMain);

        }
    }
}
