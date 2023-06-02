using System;

namespace InputCheck
{
    public class Input
    {




        public static int EnterInt()
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

        protected static double EnterDouble()
        {
            double something = 0;
            string buf;
            bool ok = false;
            while (!ok)
            {
                buf = Console.ReadLine();
                ok = Double.TryParse(buf, out something);
                if (ok == false) Console.WriteLine("Ошибка ввода\n");
            }
            return something;
        }

        static public int EnterSize()
        {
            int size = 0;
            bool ok = false;
            while (!ok)
            {
                size = EnterInt();
                if (size > 0) ok = true;
                else Console.WriteLine("Размер не может быть отрицательным\n");
            }
            return size;
        }

        static public int EnterSize(int key)
        {
            int size = 0;
            bool ok = false;
            while (!ok)
            {
                size = EnterInt();
                if (size >= 0) ok = true;
                else Console.WriteLine("Размер не может быть отрицательным\n");
            }
            return size;
        }


        protected bool SetSomething(string condition, ref double something, params double[] Limits)
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
                    something = EnterDouble();
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
                    something = EnterDouble();
                    if (something > Limits[0]) ok = true;
                    else Console.WriteLine(condition + "\n");
                }
                return true;
            }
        }

        protected bool SetSomething(string condition, ref int something, params int[] Limits)
        {
            if (Limits.Length == 0)
            {
                return false;
            }
            else if (Limits.Length == 2)
            {
                bool ok = false;
                while (!ok)
                {
                    something = EnterInt();
                    if (something > Limits[0] && something < Limits[1]) ok = true;
                    else Console.WriteLine(condition);
                }
                return true;
            }
            else
            {
                bool ok = false;
                while (!ok)
                {
                    something = EnterInt();
                    if (something > Limits[0]) ok = true;
                    else Console.WriteLine(condition + "\n");
                }
                return true;
            }
        }
    }
}
