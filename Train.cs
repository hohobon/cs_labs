﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    internal class Train : Vehicle
    {
        int numOfWagons;
        int numOfLocomotives;
        int numOfSeatsPerWagon;
        //int seatsPerWagon;
        string type;
        int wghtOfLocomotive;
        int wghtOfWagon;
        int routeNum;

        string[] types =
        {
            "пассажирский","грузовой","хозяйственный",
            "воинский", "санитарный", "броневой"
        };
        public int NumOfWagons
        {
            get => numOfWagons;
            set
            {
                if (value > 0) numOfWagons = value;
                else numOfWagons = 0;
                name = $"{type} {routeNum}-{numOfLocomotives}-{numOfWagons}";
            }
        }
        public string Type
        {
            get => type;
            set
            {
                type = value;
                name = $"{type} {routeNum}-{numOfLocomotives}-{numOfWagons}";
            }
        }
        public int WghtOfLocomotive
        {
            get => wghtOfLocomotive;
            set
            {
                if (value > 0) wghtOfLocomotive = value;
                else wghtOfLocomotive = 10;
            }
        }
        public int WghtOfWagon
        {
            get => wghtOfWagon;
            set
            {
                if (value > 0) wghtOfWagon = value;
                else wghtOfWagon = 15;
            }
        }
        public int RouteNum
        {
            get => routeNum;
            set
            {
                if (value > 0 && value < 1000) routeNum = value;
                else routeNum = 0;
                name = $"{type} {routeNum}-{numOfLocomotives}-{numOfWagons}";
            }
        }
        public int NumOfLocomotives
        {
            get => numOfLocomotives;
            set
            {
                if (value != 1 && value != 2) numOfLocomotives = value;
                else numOfLocomotives = 1;
                name = $"{type} {routeNum}-{numOfLocomotives}-{numOfWagons}";
            }

        }
        public int NumOfSeatsPerWagon
        {
            get => numOfSeatsPerWagon;
            set
            {
                if (value >= 0) numOfSeatsPerWagon = value;
                else numOfSeatsPerWagon = 0;
            }
        }

        public Train()
        { 
            numOfWagons = rnd.Next(0, 100);
            numOfLocomotives = rnd.Next(0,3);
            numOfSeatsPerWagon = rnd.Next(0,80);
            type = types[rnd.Next(types.Length - 1)];
            wghtOfLocomotive = rnd.Next(40 - 80);
            wghtOfWagon = rnd.Next(10, 200);
            routeNum = rnd.Next(1, 940);
            weight = numOfWagons * wghtOfWagon + numOfLocomotives * wghtOfLocomotive;
            name = $"{type} {routeNum}-{numOfLocomotives}-{numOfWagons}";
            seats = numOfSeatsPerWagon * numOfWagons;
        }
        public Train(int numOfWagons, int numOfLocomotives, int numOfSeatsPerWagon, string type, int wghtOfLocomotive, int wghtOfWagon, int routeNum)
        {
            NumOfWagons = numOfWagons;
            NumOfLocomotives = numOfLocomotives;
            NumOfSeatsPerWagon = numOfSeatsPerWagon;
            Type = type;
            WghtOfLocomotive = wghtOfLocomotive;
            WghtOfWagon = wghtOfWagon;
            RouteNum = routeNum;
            NumOfWagons = numOfWagons;
            weight = numOfWagons * wghtOfWagon + numOfLocomotives * wghtOfLocomotive;
            name = $"{type} {routeNum}-{numOfLocomotives}-{numOfWagons}";
            seats = numOfSeatsPerWagon * numOfWagons;

        }
        public Train(Train train)
        {
            this.numOfLocomotives = train.numOfLocomotives;
            this.numOfWagons = train.numOfWagons;
            this.numOfSeatsPerWagon = train.numOfSeatsPerWagon;
            this.wghtOfLocomotive = train.wghtOfLocomotive;
            this.wghtOfWagon = train.wghtOfWagon;
            this.type = train.type;
            this.routeNum = train.routeNum;
            this.name = train.name;
            this.weight = train.weight;
            this.seats = train.seats;
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
            cloneTrain.name = "Клон" + this.name;
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