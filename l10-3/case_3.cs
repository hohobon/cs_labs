using ENTGS;
using MyVehicle;
using System;

namespace l10_3
{
    internal class Case_3
    {
        static public Object GetRndVehicle()
        {
            Random rnd = new Random();
            int switchChoice = rnd.Next(1, 5);
            switch (switchChoice)
            {
                case 1: return new Vehicle();
                case 2: return new Car();
                case 3: return new Train();
                case 4: return new Express();
            }
            return null;
        }
        public static bool MassNullCheck(IExecutable[] executables)
        {
            if (executables != null) return true;
            else
            {
                Console.WriteLine("Массив пуст\n");
                return false;
            }
        }
        static public void CreateMass(ref IExecutable[] executables)
        {
            Console.WriteLine("Введите размер массива:");
            int massSize = Enter.Int();
            executables = new IExecutable[massSize];
            for (int i = 0; i < executables.Length; i++)
            {
                executables[i] = (IExecutable)GetRndVehicle();
            }
            Console.WriteLine("Массив создан\n");
        }
        static public void ShowMass(ref IExecutable[] executables)
        {
            Console.WriteLine("Вывод массива в консоль:\n");
            if (MassNullCheck(executables) != false)
            {
                foreach (IExecutable executable in executables) { executable.Show(); }
            }
        }
        static public void SortMass(ref IExecutable[] executables)
        {
            string menuText =
                "1 Сортировка интерфейсом IComparable и методом Sort класса Array и \n" +
                "2 Сортировка интерфейсом ICompare и методом Sort класса Array IComparable\n" +
                "3 Выход\n";
            bool menuCycle = true;
            int menuChoice;
            while (menuCycle)
            {
                if (MassNullCheck(executables) == false) menuCycle = false;
                else
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
        }
        static public void SortClassArray(ref IExecutable[] executables, bool type)
        {
            switch (type)
            {
                case true:
                    Array.Sort(executables);
                    ; break;
                case false:
                    Array.Sort(executables, new SortByWeigh());
                    foreach (IExecutable executable in executables) executable.Show();
                    int Found = Array.BinarySearch(executables, executables[0]);
                    if (Found == -1) Console.WriteLine("Элемент не найден\n");
                    else Console.WriteLine($"Элемент найден {executables[0]}\n");
                    ; break;
            }
        }
        static public void Search(ref IExecutable[] executables)
        {

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
            IExecutable[] executables = null;
            Menu(ref executables);
        }
    }
}
