using MyVehicle;
using ENTGS;
using System;
using System.Globalization;

namespace l10
{
    internal class case_1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размер массива");
            int size = Enter.Int();
            Random rnd = new Random();
            Object[] mass = new Object[size];
            int switchChoice;
             for (int i = 0; i < size; i++) 
            {
                switchChoice = rnd.Next(1,5);
                switch (switchChoice)
                {
                    case 1:
                        mass[i] = new Vehicle();
                        break;
                    case 2:
                        mass[i] = new Car();
                        break;
                    case 3:
                        mass[i] = new Train();
                        break;
                    case 4:
                        mass[i] = new Express();
                        break;
                }
            }
            foreach (Object obj in mass) Console.WriteLine($"{obj} {obj.GetType()}");
        }
    }
}
