using System;

namespace MyVehicle
{
    public class Express : Train
    {
        public override string Type => type;
        public override int NumOfLocomotives => numOfLocomotives;

        private int numOfBusinessWagons;
        private int numOfDefaultWagons;
        private int numOfSeatsPerBusinessW;
        private int numOfSeatsPerDefaultW;

        public int NumOfBusinessWagons
        {
            get => numOfBusinessWagons;
            set
            {
                if (value > 0) numOfBusinessWagons = value;
                else numOfBusinessWagons = 4;
                RefreshSeats();
                RefreshWagons();
            }
        }
        public int NumOfSeatsPerBusinessW
        {
            get => numOfSeatsPerBusinessW;
            set
            {
                if (value > 0 && value < 99)
                {
                    if (value > 9) numOfSeatsPerBusinessW = value;
                    else numOfSeatsPerBusinessW = value * 10;
                }
                else numOfSeatsPerBusinessW = 48;
                RefreshSeats();
            }
        }
        public int NumOfDefaultWagons
        {
            get => numOfDefaultWagons;
            set
            {
                if (value > 0) numOfDefaultWagons = value;
                else numOfDefaultWagons = 4;
                RefreshSeats();
                RefreshWagons();
            }
        }
        public int NumOfSeatsPerDefaultW
        {
            get => numOfSeatsPerDefaultW;
            set
            {
                if (value > 0 && value < 99)
                {
                    if (value > 9) numOfSeatsPerDefaultW = value;
                    else numOfSeatsPerDefaultW = value * 10;
                }
                else numOfSeatsPerDefaultW = 64;
                RefreshSeats();
            }
        }

        public override int NumOfWagons
        {
            get => numOfWagons;
        }
        private void RefreshWagons()
        {
            numOfWagons = numOfBusinessWagons + numOfDefaultWagons;
            RefreshName();
        }
        public override int RouteNum
        {
            get => routeNum;
            set
            {
                if (value > 0 && value < 1000) routeNum = value;
                else routeNum = 700;
                RefreshName();
            }
        }

        public override int Seats { get => seats; }

        private void RefreshSeats()
        {
            seats = numOfSeatsPerBusinessW * numOfBusinessWagons + numOfSeatsPerDefaultW * numOfDefaultWagons;
            numOfSeatsPerWagon = (int)Math.Round((double)(numOfSeatsPerBusinessW + numOfSeatsPerDefaultW) / 2, MidpointRounding.AwayFromZero);
        }
        public override string Name { get => name; }
        private void RefreshName()
        {
            name = $"{type} экспресс {routeNum}-{numOfLocomotives}-{numOfWagons}";
        }

        public Express()
        {
            type = "Пассажирский";
            numOfLocomotives = 2;
            RouteNum = rnd.Next(700, 890);
            NumOfBusinessWagons = rnd.Next(4, 8);
            NumOfDefaultWagons = rnd.Next(4, 12);
            NumOfSeatsPerBusinessW = 48;
            NumOfSeatsPerDefaultW = 64;
            WghtOfLocomotive = rnd.Next(20, 40) * 10;
            WghtOfWagon = rnd.Next(10, 20) * 10;
        }
        public Express(int routeID, int numOfBW, int numOfSPerBW, int numOfDW, int numOfSPerDW, int wghtOfW, int wghtOfL)
        {
            type = "Пассажирский";
            numOfLocomotives = 2;
            RouteNum = routeID;
            NumOfBusinessWagons = numOfBW;
            NumOfSeatsPerBusinessW = numOfSPerBW;
            NumOfDefaultWagons = numOfDW;
            NumOfSeatsPerDefaultW = numOfSPerDW;
            WghtOfLocomotive = wghtOfL;
            WghtOfWagon = wghtOfW;
        }
        public Express(Express express)
        {
            type = "Пассажирский";
            numOfLocomotives = 2;
            RouteNum = express.RouteNum;
            NumOfBusinessWagons = express.NumOfBusinessWagons;
            NumOfDefaultWagons = express.NumOfDefaultWagons;
            NumOfSeatsPerBusinessW = express.NumOfSeatsPerBusinessW;
            NumOfSeatsPerDefaultW = express.NumOfSeatsPerDefaultW;
            NumOfSeatsPerWagon = express.NumOfSeatsPerWagon;
            WghtOfLocomotive = express.WghtOfLocomotive;
            WghtOfWagon = express.WghtOfWagon;
        }
        public override object Clone()
        {
            Express expressClone = new Express(this);
            expressClone.name = "Клон " + this.name;
            return expressClone;
        }
        public override Vehicle ShallowCopy()
        {
            return (Train)MemberwiseClone();
        }
        public override bool Equals(object obj)
        {
            Express v = (Express)obj;
            return name == v.Name && weight == v.Weight && seats == v.Seats;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override int CompareTo(object obj)
        {
            return string.Compare(Name, ((Express)obj).Name);
        }
    }
}
