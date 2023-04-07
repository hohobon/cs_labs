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
        protected double speed; //  Km/H
        protected double weight; //  Kg
        protected Random rnd = new Random();

        public string Name { get => name; set => name = value; }
        virtual public double Speed 
        {   get => speed; 
            set 
            {   if (value > 0) speed = value;
                else 
                { 
                Console.WriteLine("\nСкорость не может быть отрицательной\nПрисвоено 0 Км/ч\n"); 
                speed = 0; 
                } 
            } 
        }
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
            Speed = rnd.Next(10, 300);
            Weight = Math.Round(0.01 * rnd.Next(1, 8600), 2) + 0.1;
        }
        public Vehicle(string n, double s, double w)
        {
            Name = n;
            Speed = s;
            Weight = w;
        }
        //public void SetSpeed()
        //{
        //    Console.WriteLine("Введите cкорость:");
        //    bool ok = false;
        //    while (!ok) ok = Something("Скорость не может быть отрицательной\n", ref speed, 0);
        //}
        public override string ToString()
        {
            return $"Tранспортное средство {name} {Speed}Kм/ч {weight} Кг";
        }
        public virtual void Show()
        {
            Console.WriteLine($"Транспортное средство:\nНазвание: {name}\n Cкорость: {Speed} Kм/ч\nВес: {weight}Кг\n");
        }

        public object Clone() => new Vehicle("Клон" + name, Speed, Weight);
        public Vehicle ShallowCopy()
        {
            return (Vehicle)MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            Vehicle v = (Vehicle)obj;
            return Speed == v.Speed && name == v.Name && weight == v.Weight;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(object obj)
        {
            //Vehicle tmp = (Vehicle)obj;
            //if (this.weight > tmp.weight) return 1;
            //if (this.weight < tmp.weight) return -1;
            //return 0;
            return string.Compare(name, ((Vehicle)obj).name);
        }
    }
}

