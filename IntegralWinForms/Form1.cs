using IntegralWinForms.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace IntegralWinForms
{
    public partial class Form1 : Form
    {

        private double SumIntegral(double x)
        {
            return (12 *x - Math.Log(11 * x) - 11);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {

        }

        private void btCalc_Click(object sender, EventArgs e)
        {
            double time;

            double a=Convert.ToDouble(tbA.Text);

            double b = Convert.ToDouble(tbB.Text);
            long N = Convert.ToInt64(nudN.Text);

            //Cursor olCursor = Cursor.Current;
            //this.Cursor = Cursors.WaitCursor;
         //   tbResult.Text = String.Empty;



            Integral int1 = new Integral(a, b, N, SumIntegral);
            double result=int1.Rectangle(out time);
            //double result = int1.CalcThreadPool();
            rtbLog.AppendText("Результат:     " + result.ToString()+Environment.NewLine);
            rtbLog.AppendText("Время:          " + time.ToString() + Environment.NewLine);

           // Integral int2 = new Integral(a, b, N, SumIntegral);
            Integral int2 = new Integral(a, b, N, SumIntegral);

          //  double result2 = int2.RectangleParallel(out time);
            double result2 = int2.RectangleParallel(out time);
            rtbLog.AppendText("Результат1:  " + result2.ToString() + Environment.NewLine);
            rtbLog.AppendText("Время1:        " + time.ToString() + Environment.NewLine);

            //rtbLog.AppendText("Результат2:" + result2.ToString() + Environment.NewLine);
            //rtbLog.AppendText("Время2:" + time.ToString() + Environment.NewLine);

        }
                       

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnDrow_Click(object sender, EventArgs e)
        {
            DrawGraph();
        }
        private void DrawGraph()
        {
            chartNTime.Series[0].Points.Clear();
            int nStart = 10000000;
            int nFinish = 100000000;
            int nStep = 20000000;
            double a = Convert.ToDouble(tbA.Text);
            double b = Convert.ToDouble(tbB.Text);

            Stopwatch sw = new Stopwatch();

            for (int n = nStart; n < nFinish; n += nStep)
            {
                sw.Start();

                Integral integ = new Integral(a, b, n, SumIntegral);
                double integ0 = integ.CalcRectangle(a, b, n, x => SumIntegral(x));


                //  Integral integ = new Integral.CalcRectangle(a, b, n, x => SumIntegral(x));

                sw.Stop();
                long time = sw.ElapsedMilliseconds;
                sw.Reset();
                chartNTime.Series[0].Points.AddXY(n, time);
            }

            ///////////////////////////////////////////////////////
            chartNTime.Series[1].Points.Clear();
            int nStart20 = 10000000;
            int nFinish20 = 100000000;
            int nStep20 = 20000000;
            // double a = Convert.ToDouble(tbA.Text);
            // double b = Convert.ToDouble(tbB.Text);

            Stopwatch sw20 = new Stopwatch();

            for (int n = nStart20; n < nFinish20; n += nStep20)
            {
                sw20.Start();

                Integral integ1 = new Integral(a, b, n, SumIntegral);
                double integ20 = integ1.CalcRectanglePar(a, b, n);


                //  Integral integ = new Integral.CalcRectangle(a, b, n, x => SumIntegral(x));

                sw20.Stop();
                long time1 = sw20.ElapsedMilliseconds;
                sw20.Reset();
                chartNTime.Series[1].Points.AddXY(n, time1);
            }
            ///////////////////////////////////////////////////////////////////////////////

            ///////////////////////////////////////////////////////

            chartNTime2.Series[0].Points.Clear();

            int nStart21 = 1;
            int nFinish21 = 15;
            int nStep21 = 1;
            int nom = 100000000;
            Stopwatch sw21 = new Stopwatch();

            for (int numb = nStart21; numb < nFinish21; numb += nStep21)
            {
                sw21.Start();

                Integral integ2 = new Integral(a, b, nom, SumIntegral);
                double integ21 = integ2.CalcThreadPool(numb);
                sw21.Stop();
                long time2 = sw21.ElapsedMilliseconds;
                sw21.Reset();
                chartNTime2.Series[0].Points.AddXY(numb, time2);
            }
            ///////////////////////////////////////////////////////////////////////////////

            DrawGraph30(a, b);
            DrawGraph31(a, b);
            DrawGraph40(a, b);
            DrawGraph41(a, b);
        }

            private void DrawGraph30(double a, double b) 
         {

            chart3.Series[0].Points.Clear();

          //  int nStart30 = 10000000;
            //int nFinish30 = 100000000;
           // int nStep30 = 20000000;
            //double a = Convert.ToDouble(tbA.Text);
            //double b = Convert.ToDouble(tbB.Text);

            Stopwatch sw30 = new Stopwatch();

         //   for (int n = nStart30; n < nFinish30; n += nStep30)
          //  {
              int nom30 = 100000000;    

                sw30.Start();

                Integral integ30 = new Integral(a, b, nom30, SumIntegral);
                double integ300 = integ30.CalcRectangle(a, b, nom30, x => SumIntegral(x));
                sw30.Stop();
                long time30 = sw30.ElapsedMilliseconds;
                sw30.Reset();
                chart3.Series[0].Points.AddY(time30);
         //   }
            }
            ///////////////////////////////////////////////////////////////////////////////

             private void DrawGraph31(double a, double b) 
        {

            chart3.Series[1].Points.Clear();

            //int nStart31 = 10000000;
            //int nFinish31 = 100000000;
            //int nStep31 = 20000000;
            //double a = Convert.ToDouble(tbA.Text);
            //double b = Convert.ToDouble(tbB.Text);
            int nom31 = 100000000;

            Stopwatch sw31 = new Stopwatch();

            //for (int n = nStart31; n < nFinish31; n += nStep31)
            //{
                sw31.Start();

                Integral integ31 = new Integral(a, b, nom31, SumIntegral);
                double integ311 = integ31.CalcRectanglePar(a, b, nom31);


                sw31.Stop();
                long time31 = sw31.ElapsedMilliseconds;
                sw31.Reset();
                chart3.Series[1].Points.AddY(time31);
             }
            //}
            ///////////////////////////////////////////////////////////////////////////////

           
            ///////////////////////////////////////////////////////////////////////////////


        

        private void DrawGraph40(double a, double b) 
        {
            int n = 100000000;
            chart4.Series[0].Points.Clear();

            Stopwatch sw40 = new Stopwatch();
            sw40.Start();

            Integral integ40 = new Integral(a, b, n, SumIntegral);

            double integ400 = integ40.CalcRectanglePar(a, b, n);

            sw40.Stop();
            long time40 = sw40.ElapsedMilliseconds;
            sw40.Reset();
            chart4.Series[0].Points.AddY(time40);        
        }

        private void DrawGraph41(double a, double b)
        {
            int numb = 16;
            
            int nom = 100000000;
            chart4.Series[1].Points.Clear();

            Stopwatch sw41 = new Stopwatch();
            sw41.Start();

            Integral integ41 = new Integral(a, b, nom, SumIntegral);
            double integ411 = integ41.CalcThreadPool(numb);

            sw41.Stop();
            long time41 = sw41.ElapsedMilliseconds;
            sw41.Reset();
            chart4.Series[1].Points.AddY(time41);
        }

       

        private void tbB_TextChanged(object sender, EventArgs e)
        {

        }

        public object n { get; set; }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }
    }
}
