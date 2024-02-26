using System;

namespace ENTGS
{
    public class Enter
    {
        public static int Int()
        {
            int something = 0;
            string buf;
            bool ok = false;
            while (!ok)
            {
                buf = Console.ReadLine();
                ok = Int32.TryParse(buf, out something);
                if (ok != true) Console.WriteLine("Ошибка ввода\n");
            }
            return something;
        }

        protected static double Double()
        {
            double something = 0;
            string buf;
            bool ok = false;
            while (!ok)
            {
                buf = Console.ReadLine();
                ok = double.TryParse(buf, out something);
                if (ok == false) Console.WriteLine("Ошибка ввода\n");
            }
            return something;
        }

        static public int Size()
        {
            int size = 0;
            bool ok = false;
            while (!ok)
            {
                size = Int();
                if (size > 0) ok = true;
                else Console.WriteLine("Размер не может быть отрицательным\n");
            }
            return size;
        }

        static public int Size(int key)
        {
            int size = 0;
            bool ok = false;
            while (!ok)
            {
                size = Int();
                if (size >= 0) ok = true;
                else Console.WriteLine("Размер не может быть отрицательным\n");
            }
            return size;
        }


        public bool Something(string condition, ref double something, params double[] Limits)
        {
            if (Limits.Length == 0)
            {
                return false;
            }
            else if (Limits.Length == 2)
            {
                //double something = 0;
                bool ok = false;
                while (!ok)
                {
                    something = Double();
                    if (something > Limits[0] && something < Limits[1]) ok = true;
                    else Console.WriteLine(condition);
                }
                return true;
            }
            else
            {
                //double tmp = 0;
                bool ok = false;
                while (!ok)
                {
                    something = Double();
                    if (something > Limits[0]) ok = true;
                    else Console.WriteLine(condition + "\n");
                }
                return true;
            }
        }

        static public bool Something(string condition, ref int something, params int[] Limits)
        {
            if (Limits.Length == 0)
            {
                return false;
            }
            else if (Limits.Length == 2)
            {
                Console.WriteLine(condition);
                bool ok = false;
                while (!ok)
                {
                    something = Int();
                    if (something > Limits[0] && something < Limits[1]) ok = true;
                    else Console.WriteLine(condition);
                }
                return true;
            }
            else
            {
                Console.WriteLine(condition);
                bool ok = false;
                while (!ok)
                {
                    something = Int();
                    if (something > Limits[0]) ok = true;
                    else Console.WriteLine(condition + "\n");
                }
                return true;
            }
        }

    }
}
