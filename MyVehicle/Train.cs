using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Train : Vehicle
    {
        protected int numOfWagons;
        protected int numOfLocomotives;
        protected int numOfSeatsPerWagon;
        protected string type;
        protected int wghtOfLocomotive;
        protected int wghtOfWagon;
        protected int routeNum;
        protected new int seats;

        readonly string[] types =
        {
            "пассажирский","грузовой","хозяйственный",
            "воинский", "санитарный", "броневой"
        };
        virtual public int NumOfWagons
        {
            get => numOfWagons;
            set
            {
                if (value > 0) numOfWagons = value;
                else numOfWagons = 0;
                RefreshSeats();
                RefreshName();
                RefreshWeight();
            }
        }
        public string Type
        {
            get => type;
            set
            {
                type = value;
                RefreshName();
            }
        }
        public int WghtOfLocomotive
        {
            get => wghtOfLocomotive;
            set
            {
                if (value > 0) wghtOfLocomotive = value; 
                else wghtOfLocomotive = 250;
                RefreshWeight();
                RefreshWeight();
            }
        }
        public int WghtOfWagon
        {
            get => wghtOfWagon;
            set
            {
                if (value > 0) wghtOfWagon = value;
                else wghtOfWagon = 150;
                RefreshWeight();
            }
        }
        virtual public int RouteNum
        {
            get => routeNum;
            set
            {
                if (value > 0 && value < 1000) routeNum = value;
                else routeNum = 0;
                RefreshName();
            }
        }
        public int NumOfLocomotives
        {
            get => numOfLocomotives;
            set
            {
                if (value != 1 && value != 2) numOfLocomotives = 1;
                else numOfLocomotives = value;
                RefreshName();
                RefreshWeight();
            }

        }
        public int NumOfSeatsPerWagon
        {
            get => numOfSeatsPerWagon;
            set
            {
                if (value > 0) numOfSeatsPerWagon = value;
                else numOfSeatsPerWagon = 0;
                RefreshSeats();
            }
        }
        public new string Name { get => name; }
        private void RefreshName()
        {
            name = $"{type} поезд {routeNum}-{numOfLocomotives}-{numOfWagons}";
        }
        private void RefreshWeight()
        {
            weight = numOfWagons * wghtOfWagon + numOfLocomotives * wghtOfLocomotive;
        }
        public new int Seats { get => seats; }

        private void RefreshSeats()
        {
            seats = numOfSeatsPerWagon * numOfWagons;
        }

        public Train()
        { 
            NumOfWagons = rnd.Next(0, 100);
            NumOfLocomotives = rnd.Next(1,2);
            NumOfSeatsPerWagon = rnd.Next(1,6) * 10;
            Type = types[rnd.Next(0, types.Length - 1)];
            WghtOfLocomotive = rnd.Next(40, 60);
            WghtOfWagon = rnd.Next(10, 200);
            RouteNum = rnd.Next(1, 940);
        }
        public Train(int numOfWagonsP, int numOfLocomotivesP, int numOfSeatsPerWagonP, string typeP, int wghtOfLocomotiveP, int wghtOfWagonP, int routeNumP)
        {
            NumOfWagons = numOfWagonsP;
            NumOfLocomotives = numOfLocomotivesP;
            NumOfSeatsPerWagon = numOfSeatsPerWagonP;
            Type = typeP;
            WghtOfLocomotive = wghtOfLocomotiveP;
            WghtOfWagon = wghtOfWagonP;
            RouteNum = routeNumP;
        }
        public Train(Train train)
        {
            NumOfLocomotives = train.numOfLocomotives;
            NumOfWagons = train.numOfWagons;
            NumOfSeatsPerWagon = train.numOfSeatsPerWagon;
            WghtOfLocomotive = train.wghtOfLocomotive;
            WghtOfWagon = train.wghtOfWagon;
            Type = train.type;
            RouteNum = train.routeNum;
        }
        public override string ToString()
        {
            return $"{name}";
        }
        public override void Show()
        {
            Console.WriteLine
            (
                $"поезд {name}\n"+
                $"мест {seats}\n" +
                $"вес {weight}т\n"
            );
        }
        public new object Clone()
        {
            Train cloneTrain = new Train(this);
            cloneTrain.Type = "клон" + this.Type;
            return cloneTrain;
        }
        public override Vehicle ShallowCopy()
        {
            return (Train)MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            Train v = (Train)obj;
            return name == v.Name && weight == v.Weight;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override int CompareTo(object obj)
        {
            return string.Compare(name, ((Train)obj).name);
        }
    }
}
