//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Collections.Concurrent;

//namespace IntegralWinForms.Classes
//{
//    public class IntegralParallelThread
//    {

//        private double _a, _b;
//        private long _n;

//        public IntegralParallelThread()
//        {
            
//        }

//        public void SetData(double a, double b, long n)
//        {
//            _a = a;
//            _b = b;
//            _n = n;
//        }

//        public double Calculate()
//        {
//            return Calculate(_a, _b, _n);
//        }

//        public double CalculateWithThreads(int numberOfThreads)
//        {
//            List<long> nPerThreads=new List<long>();
//            double h = (_b - _a)/_n;
//            long nPerThread = _n/numberOfThreads;
//            long nlastThread =nPerThread+ _n % numberOfThreads;

//            List<double> intervals = new List<double>();
//            double currentInterval=_a;
//            intervals.Add(currentInterval);
//            for (int i = 0; i < numberOfThreads-1; i++)
//            {
//                nPerThreads.Add(nPerThread);
//                currentInterval +=nPerThreads[nPerThreads.Count-1]*h;
//                intervals.Add(currentInterval);
//            }

//            intervals.Add(_b);
//            nPerThreads.Add(nlastThread);
			
//            List<Thread> results= new List<Thread>();
//                                                                 // List<double> results= new List<double>();
//            double[] results = new double[numberOfThreads];

//            for (int i = 0; i < numberOfThreads; i++)
//            {
//                int ix = i;
//                Thread thread = new Thread (
//                    ()=>
//                        {
//                                                                                //  results.Add(Calculate(intervals[ix],intervals[ix+1],nPerThreads[ix]));
//            results[ix] = Calculate(intervals[ix], intervals[ix + 1], nPerThreads[ix]);
//                        }
//            );
//            threads.Add(thread);
//            thread.Name=i.ToString();
//            thread.Start();
//        }
//        for (int i=0; i < numberOfThreads; i++)
//            threads[i].Join();
//        double result = 0;
//                foreach (var r in results)
//                {
//                    result += r;
//                }
//            return result;
//        }
//        private double Calculate(double a, double b, long n)
//        {
//            long i;
//            double result = 0;
//            double h = (b - a) / n;

//            for (i = 0; i < n; i++)
//            {
//                result += F(a + h * (i)); //Вычисляем в средней точке и добавляем в сумму
//            }

//            result *= h;

//            return result;
//        }

//        private double F( double x)
//        {
//            return 12 * x - Math.Log(11 * x) - 11;
//        }
//    }
//}
