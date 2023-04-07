using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ENTGS;
using MyVehicle;

namespace MyVehicle
{
    public interface IExecutable { void Show(); }

    public class Vehicle: IExecutable, ICloneable, IComparable
    {
        protected string name;
        protected double weight; //  Kg
        protected int seats;
        protected Random rnd = new Random();

        public string Name { get => name; set => name = value; }
        
        virtual public double Weight 
        {   get => weight; 
            set 
            {   if (value > 0) weight = value;
                else 
                {   
                    Console.WriteLine("Вес не может быть отрицательным\nПрисвоено 0 кг\n"); 
                    weight = 0; 
                } 
            } 
        }
        virtual public int Seats
        {
            get => seats;
            set
            {
                if (value > 0) weight = value;
                else
                {
                    Console.WriteLine("должно быть минимум одно место\nПрисвоено 1 место\n");
                    seats = 1;
                }
            }
        }

        public Vehicle()
        {
            string[] names = 
            { 
                "Велосипед", "Самолёт", "Самокат", "Поезд", "Машина", 
                "Мотоцикл", "Скутер", "Катер", "Корабль", "Яхта", 
                "Внедорожник", "Фургон", "Истребитель", "Экспересс", 
                "Багги", "Вертолёт", "Повозка" 
            };

            Name = names[rnd.Next(0, names.Length - 1)];
            Weight = Math.Round(0.01 * rnd.Next(1, 8600), 2) + 0.1;
        }
        public Vehicle(string n, double w)
        {
            Name = n;
            Weight = w;
        }
        public override string ToString()
        {
            return $"Tранспортное средство {name} {weight} Кг";
        }
        public virtual void Show()
        {
            Console.WriteLine($"Транспортное средство:\nНазвание: {name}\nВес: {weight}Кг\n");
        }

        public object Clone() => new Vehicle("Клон" + name, Weight);
        public Vehicle ShallowCopy()
        {
            return (Vehicle)MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            Vehicle v = (Vehicle)obj;
            return name == v.Name && weight == v.Weight;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            return string.Compare(name, ((Vehicle)obj).name);
        }
    }
}

