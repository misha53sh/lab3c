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
//    class IntegralParallelFor
//    {
//        private double a;
//        private double b;
//        private object n;

//        public IntegralParallelFor(double a, double b, object n)
//        {
//            // TODO: Complete member initialization
//            this.a = a;
//            this.b = b;
//            this.n = n;
//        }
//        // helper function to solve equation under integral
//        static public double F11(double x)
//        {
//            return 12 * x - Math.Log(11 * x) - 11; 
//        }

//        // method for calculate integral with trapeze method
//        static public double IntegralParallelFor(double a, double b, double n)
//        {


//            double S;
//            // calculate number of steps
//            int h = (int)((b - a) / n);
//            // object for lock mutex and synchronize threads
//            object monitor = new object();
//            S = (F11(a) + F11(b)) / 2;

//            // Every thread have own local data, 
//            // and thread calculate own part of integral
//            // then it sum in main thread with S+= local
//            Parallel.For(0, h, () => 0.0, (i, state, local) =>
//            {

//                local += F11(a + h * i);
//                return local;
//            }, local => { lock (monitor) S += local; });

//            S *= h;
//            return S;
//        }
        
       
//    }
//}
