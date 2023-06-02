using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVehicle;
using ENTGS;

namespace l10_3
{
    internal class case_3
    {
        static public bool MassNullCheck(ref IExecutable[] executables)
        {
            if (executables != null) return true;
            else return false;
        }
        static public void CreateMass(ref IExecutable[] executables)
        {
            Random rnd = new Random();
            Console.WriteLine("Введите размер массива:");
            int massSize = Enter.Int();
            int switchChoice;
            
            for (int i = 0; i < executables.Length; i++)
            {
                switchChoice = rnd.Next(1, 5);
                switch (switchChoice)
                {
                    case 1:
                        executables[i] = new Vehicle();
                        break;
                    case 2:
                        executables[i] = new Car();
                        break;
                    case 3:
                        executables[i] = new Train();
                        break;
                    case 4:
                        executables[i] = new Express();
                        break;
                }
            }
            Console.WriteLine("Массив создан\n");
        }
        static public void ShowMass(ref IExecutable[] executables)
        {
            Console.WriteLine("Вывод массива в консоль:\n");
            if (executables != null) foreach (IExecutable executable in executables) { executable.Show(); }
            else Console.WriteLine("Массив пуст\n");
        }
        static public void SortMassClassic(ref IExecutable[] executables)
        {
            string menuText =
                "1 Создать массив\n" +
                "2 Выввести массив\n" +
                "3 Выход\n";
            bool menuCycle = true;
            int menuChoice;
            while (menuCycle)
            {
                menuChoice = 0;
                while (Enter.Something(menuText, ref menuChoice, 0, 5) != true) ;
                switch (menuChoice)
                {
                    case 1: CreateMass(ref executables); break;
                    case 2: ShowMass(ref executables); break;
                    case 3: Console.WriteLine(); break;
                    case 5: menuCycle = false; break;
                }
            }
        }
        static public void Menu(ref IExecutable[] executables)
        {
            string menuText =
                "1 Создать массив\n" +
                "2 Выввести массив\n" +
                "3 Сортировка массива\n" +
                "4 Клонирование\n" +
                "5 Выход\n";
            bool menuCycle = true;
            int menuChoice;
            while (menuCycle)
            {
                menuChoice = 0;
                while (Enter.Something(menuText, ref menuChoice, 0, 5) != true) ;
                switch (menuChoice)
                {
                    case 1: CreateMass(ref executables); break;
                    case 2: ShowMass(ref executables); break;
                    case 3: Console.WriteLine(); break;
                    case 5: menuCycle = false; break;
                }
            }
        }
        static void Main(string[] args)
        {
            IExecutable[] executables =  null;
            Menu(ref executables);
        }
    }
}
