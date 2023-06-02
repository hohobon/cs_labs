using System;

namespace MyVehicle
{
    public interface IExecutable { void Show(); }

    public class Vehicle : IExecutable, ICloneable, IComparable
    {
        protected string name;
        protected double weight; //  Kg
        protected int seats;
        protected static Random rnd = new Random();

        static readonly string[] names =
        {
             "Велосипед", "Самолёт", "Самокат", "Поезд", "Машина",
             "Мотоцикл", "Скутер", "Катер", "Корабль", "Яхта",
             "Внедорожник", "Фургон", "Истребитель", "Экспересс",
             "Багги", "Вертолёт", "Повозка"
        };
        public virtual string Name { get => name; set => name = value; }

        public virtual double Weight
        {
            get => weight;
            set
            {
                if (value >= 0) weight = value;
                else
                {
                    Console.WriteLine("Вес не может быть отрицательным\nПрисвоено 0 кг\n");
                    weight = 0;
                }
            }
        }
        public virtual int Seats
        {
            get => seats;
            set
            {
                if (value > 0) seats = value;
                else seats = 1;
            }
        }

        public Vehicle()
        {
            Name = names[rnd.Next(0, names.Length - 1)];
            Weight = Math.Round(0.01 * rnd.Next(1, 8600), 2) + 0.1;
            Seats = rnd.Next(1, 20);
        }
        public Vehicle(string n, double w, int s)
        {
            Name = n;
            Weight = w;
            Seats = s;
        }
        public Vehicle(Vehicle vehicle)
        {
            Name = vehicle.Name;
            Weight = vehicle.Weight;
            Seats = vehicle.Seats;
        }
        public override string ToString()
        {
            return $"Tранспорт средство {name} m{weight} мест {seats}";
        }
        public virtual void Show()
        {
            Console.WriteLine($"Транспорт средство:\nНазвание: {name}\nВес: {weight}\nМест: {seats}\n");
        }

        public virtual object Clone()
        {
            Vehicle cloneVehicle = new Vehicle(this);
            return cloneVehicle;
        }
        public virtual Vehicle ShallowCopy()
        {
            return (Vehicle)MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            if ((obj == null) || (GetType() != obj.GetType()))
            {
                return false;
            }
            else
            {
                Vehicle v = (Vehicle)obj;
                return (name == v.Name) && (weight == v.Weight) && (seats == v.Seats);
            }
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public virtual int CompareTo(object obj)
        {
            return string.Compare(name, ((Vehicle)obj).name);
        }
    }
}

