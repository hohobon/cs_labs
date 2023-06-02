using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVehicle;
using ENTGS;
using System.ComponentModel.Design;

namespace l10_2
{
    internal class case_2
    {
        static public void option1()
        {
            Console.WriteLine("Введите кол-во экспрессов\n");
            int numOfExpresses =  Enter.Int();
            int sumOfBusinessSeats = 0;
            Express[] expresses = new Express[numOfExpresses];
            for (int i = 0; i < numOfExpresses; i++) 
            {
                expresses[i] = new Express();
            }
            foreach (Express exp in expresses) 
            {
                Console.WriteLine(exp.ToString() + $"Мест бизнесс класса {exp.NumOfSeatsPerBusinessW * exp.NumOfBusinessWagons}\n");
                sumOfBusinessSeats += exp.NumOfSeatsPerBusinessW * exp.NumOfBusinessWagons;
            }
            Console.WriteLine($"Кол-во мест бизнес класса во всех Эксспресса:\n {sumOfBusinessSeats}\n");
        }
        static public void option2()
        {
            Console.WriteLine("Введите кол-во автомобилей\n");
            int numOfCars = Enter.Int();
            Car fatCar = new Car("0","0",'0',"0",0,0,0,0);
            Car[] cars = new Car[numOfCars];
            for (int i = 0; i < numOfCars; i++)
            {
                cars[i] = new Car();
            }
            foreach (Car car in cars)
            {
                Console.WriteLine(car.ToString() + $"Объем Двигателя {car.EngineCapacity}");
                if (car.EngineCapacity > fatCar.EngineCapacity) fatCar = car;
            }
            Console.WriteLine($"Автомобиль с самым большим объемом двигателя:\n {fatCar}\n");
        }
        static public void option3()
        {
            Console.WriteLine("Введите кол-во экспрессов\n");
            int numOfTrains = Enter.Int();
            int SumOfWagons = 0;
            double AverageOfWagons;
            Train[] Trains = new Train[numOfTrains];
            for (int i = 0; i < numOfTrains; i++)
            {
                Trains[i] = new Train();
            }
            foreach (Train train in Trains)
            {
                Console.WriteLine(train.ToString() + $"Вагонов {train.NumOfWagons}");
                SumOfWagons += train.NumOfWagons;
            }
            AverageOfWagons = SumOfWagons / numOfTrains;
            Console.WriteLine($"Среднее кол-во вагонов у поездов:\n {AverageOfWagons}\n");
        }
        static public void Menu()
        {
            string menuText =
                "1 Кол-во мест бизнесс класса во всех экспрессах\n" +
                "2 Автомобиль с самым большим объемом двигателя\n" +
                "3 Среднее кол-во вагонов у поездов\n" +
                "4 Выход\n";
            bool menuCycle = true;
            int menuChoice;
            while (menuCycle)
            {
                menuChoice = 0;
                while (Enter.Something(menuText, ref menuChoice, 0, 5) != true) ;
                switch (menuChoice)
                {
                    case 1: option1(); break;
                    case 2: option2(); break;
                    case 3: option3(); break;
                    case 4: menuCycle = false; break;
                }
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
