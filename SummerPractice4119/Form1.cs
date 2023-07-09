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
        Rectangle sas2;
        public static Timer timer;
        Circle circle3;
        bool started = false;
        Graphics g;
        public delegate void ListHandler();
        public delegate void Stoppin();
        public static event Stoppin rectStop;
        public Form1()
        {

            InitializeComponent();
            g = panelMain.CreateGraphics();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!started)
            {

                sas = new Rectangle(250, 70, g);
                sas.Moving = true;
                started = true;
                timer = new Timer();
                timer.Interval = 20;
                timer.Tick += sas.MoveTimerEventX;                           
                timer.Start();
                sas.rectangleStop += sas.RectangleMovingStop;
                timer.Tick += recCheck;
            
            }
        }
        public void recCheck(Object myObject, EventArgs myEventArgs)
        {

            if (sas.Moving == false)
            {

                timer.Tick -= sas.MoveTimerEventX;
                circle.Moving = true;
                circle1.Moving = true;
                circle2.Moving = true;
                circle3.Moving = true;
                timer.Tick += circle.MoveTimerEventX;
                timer.Tick += circle1.MoveTimerEventX;
                timer.Tick += circle2.MoveTimerEventY;
                timer.Tick += circle3.MoveTimerEventY;
                timer.Tick -= recCheck;

            }

        }
        



        private void panelMain_Click(object sender, EventArgs e)
        {
            circle = new Circle(600, 100, 20, g);
            circle1 = new Circle(500, 250, 20, g);
            circle2 = new Circle(200, 50, 20, g);
            circle3 = new Circle(20, 250, 20, g);
        }
    }
}
