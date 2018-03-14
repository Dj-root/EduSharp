using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Nutshell.Chapter4.Delegates
{
    public delegate int Transformer(int x);
    public delegate T Transformer<T>(T arg);

    public delegate void ProgressReporter(int percentComplete);
    class Util
    {
        public static void Transform<T>(T[] values, Transformer<T> t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t(values[i]);
            }
        }

        public static void TransformAll(int[] values, ITransformer t)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = t.Transform(values[i]);
            }
        }

//        public static void Transform(int[] values, Transformer t)
//        {
//            for (int i = 0; i < values.Length; i++)
//            {
//                values[i] = t(values[i]);
//            }
//        }

        public static void HardWork(ProgressReporter p)
        {
            for (int i = 0; i < 10; i++)
            {
                p(i * 10);
                System.Threading.Thread.Sleep(100);
            }
            
        }
    }
}
