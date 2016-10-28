using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
//using IntegralMultihtread.Classes;


namespace IntegralWinForms.Classes
{

    public class MyEventArgs : EventArgs
    {
        public double Result;
    }

    public class Integral
    {

        public event EventHandler<MyEventArgs> CalculationFinished;
        protected void OnCalculationFinished(double result)
        {
            if (CalculationFinished != null)
            {
                MyEventArgs args = new MyEventArgs();
                args.Result = result;
                CalculationFinished(this, args);
            }
        }



        public int k = 0;
        public Func<double, double> _F;
        public double a;
        public double b;
        public long n;

        public double A
        {
            get
            {
                return a;
            }
        }

        public double B
        {
            get
            {
                return b;
            }
        }

        public long N
        {
            get
            {
                return n;
            }
        }

        public void SetData(double a, double b, long N, Func<double, double> f)
        {
            this.a = a;
            this.b = b;
            this.n = N;
            _F = f;

        }
        public Integral(double a, double b, long N, Func<double, double> f)
        {
            SetData(a, b, N, f);



        }

        public double Rectangle(out double time)
        {
            Stopwatch sw1;
            sw1 = new Stopwatch();
            sw1.Start();
            time = 0;
            double res = CalcRectangle(a, b, n, _F);
            sw1.Stop();
            time = sw1.ElapsedMilliseconds;
            return res;

        }

        public double RectangleParallel(out double time)
        {
            //Thread oneThread = new Thread(CalcRectanglePar(a, b, n, _F));
            //oneThread.Start();
            Stopwatch sw2;
            sw2 = new Stopwatch();
            sw2.Start();

            time = 0;
            double res = CalcRectanglePar(a, b, n);
            sw2.Stop();
            time = sw2.ElapsedMilliseconds;
            return res;
            //oneThread.Join();
        }


        public double CalcRectangle(double a, double b, long N, Func<double, double> _F)
        {
            double h = (b - a) / n;
            double S = 0;
            for (int i = 0; i < n; i++)
            {
                S += _F(a + i * h);
            }
            S *= h;
            return S;


        }
        static public double F11(double x)
        {
            return (12 * x - Math.Log(11 * x) - 11);
        }

        public double CalcRectanglePar(double a, double b, long n)
        {
            double S;
            // calculate number of steps
            double h = (double)((b - a) / n);
            // object for lock mutex and synchronize threads
            object monitor = new object();
            S = (F11(a) + F11(b)) / 2;

            // Every thread have own local data, 
            // and thread calculate own part of integral
            // then it sum in main thread with S+= local
            Parallel.For(0, n, () => 0.0, (i, state, local) =>
            {

                local += F11(a + h * i);
                return local;
            }, local => { lock (monitor) S += local; });

            S *= h;

            return S;


        }

        public double CalcThreadPool(int numb)
        {
            double Sum = 0;
            double ret = 0;
            double[] resultPool = new double[numb];

            var events = new ManualResetEvent[numb];
            for (int i = 0; i < numb; i++)
            {
                int y = i;
                events[i] = new ManualResetEvent(false);
                ThreadPool.QueueUserWorkItem((_) =>
                {
                    resultPool[y] = ThreadPoolMet(a, b, n, k);
                    events[y].Set();
                    ret = resultPool[y];
                });

            }
            Sum = Sum + ret;
            //WaitHandle.WaitAll(events);
            for (int i = 0; i < numb; i++)
                events[i].WaitOne();
            
            return Sum;
            ///////////////////////////////////////////////////////////////////
        }

        public double ThreadPoolMet(double a, double b, long n, int k)/////////////////////////////////////////////////////////////////////////////////////////
        {
            k++;
            double h = (b - a) / n;
            double S = 0;
            for (double i = (1 - k) * 0.25 * n; i < 0.25 * k * n; i++)
            {
                S += F11(a + i * h);
            }
            S *= h;
            return S;
            //}
          }
       
        
    }

}