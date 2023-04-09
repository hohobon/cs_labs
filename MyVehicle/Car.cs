using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle 
{
    public class Car : Vehicle
    {
        protected string brand;
        protected string model;
        protected char type;
        protected string bodyWork;
        protected float engineСapacity;
        protected int year;

        static char[] types = { 'A', 'B', 'C', 'D', 'E', 'F', 'J', 'M', 'S' };
        static string[] bodyWorks =
        {
            "седан", "купе", "универсал", "лимузин",
            "хэтчбек", "лифтбэк","пикап кабриолет",
            "минивэн", "микроавтобус", "внедорожник"
        };
        static string[] brands =
        {
          "BMV", "Audi", "Bugatti", "Buick", "Cadillac",
          "Chery", "Citroen", "Fiat", "Honda", "Jeep", "Lexus",
        };
        static string[] models =
        {
            "A1", "A2", "A3", "A4",
            "A5", "A6", "A7", "A8",
            "Q3", "Q6", "RS5", "Typ A",
            "Typ E", "Typ SS", "V8",
            "BLS", "ELR", "SRX","ATS-V",
            "ATS", "XTS", "C3", "C5",
            "C6", "Xsara", "Visa"
        };
        public string Brand
        {
            get => brand;
            set
            {
                brand = value;
                name = brand + " " + model;
            }
        }
        public string Model
        {
            get => model;
            set
            {
                model = value;
                name = brand + " " + model;
            }
        }
        public char Type
        {
            get => type;
            set => type = value;
        }
        public string BodyWork
        {
            get => bodyWork;
            set => bodyWork = value;
        }
        public float EngineCapacity
        {
            get => engineСapacity;
            set
            {
                if (value > 0) engineСapacity = value;
                else
                {
                    Console.WriteLine("объем двигателя не может быть отрицательным\n Присовено 0.5\n");
                    engineСapacity = (float)0.5; 
                }
            }
        }
        public int Year
        {
            get => year;
            set
            {
                if (value > 0) year = value;
                else
                {
                    Console.WriteLine("год не может быть мегьше нуля\nприсвоено 2012");
                    year = 2012;
                }
            }
        }
        public Car()
        {
            brand = brands[rnd.Next(0, brands.Length - 1)];
            Model = models[rnd.Next(0, models.Length - 1)];
            type = types[rnd.Next(0, types.Length - 1)];
            bodyWork = bodyWorks[rnd.Next(0, bodyWorks.Length - 1)];
            engineСapacity = (float)(Math.Round(0.01 * rnd.Next(100, 5200), 2));
            year = rnd.Next(1950, 2023);
            weight = Math.Round(0.01 * rnd.Next(1, 8600), 2) + 0.1;
            seats = rnd.Next(1, 7);
        }
        public Car(string brandP, string modelP, char typeP, string bodyWorkP, float engCapacityP, int yearP, double weightP, int seatsP)
        {
            Brand = brandP;
            Model = modelP;
            Type = typeP;
            BodyWork = bodyWorkP;
            EngineCapacity = engCapacityP;
            year = yearP;
            Weight = weightP;
            Seats = seatsP;
        }
        public Car(Car car)
        {
            this.brand = car.brand;
            this.Model = car.model;
            this.Type = car.type;
            this.BodyWork = car.bodyWork;
            this.seats = car.seats;
            this.weight = car.weight;
            this.engineСapacity = car.engineСapacity;
            this.year = car.year;
        }
        public override string ToString()
        {
            return $"атвомобиль {bodyWork} категории {type} {name} {year}г";
        }
        public override void Show()
        {
            Console.WriteLine
            (
                $"автомобиль\n" +
                $"категория {type}" +
                $"{name}\n" +
                $"{bodyWork}\n" +
                $"год {year}\n" +
                $"мест {seats}\n" +
                $"V дигателя {engineСapacity}\n" +
                $"Вес {weight}\n"
            );
        }
        public new object Clone() => new Car("клон" + brand, model, type, bodyWork, engineСapacity, year, weight, seats);
        public override Vehicle ShallowCopy()
        {
            return (Car)MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            Car v = (Car)obj;
            return name == v.Name && weight == v.Weight;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override int CompareTo(object obj)
        {
            return string.Compare(name, ((Car)obj).name);
        }

    }
}
