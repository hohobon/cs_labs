using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Express : Train
    {
        protected readonly new string type;
        protected int numOfBusinessWagons;
        protected int numOfDefaultWagons;
        protected int numOfSeatsPerBusinessW;
        protected int numOfSeatsPerDefaultW;
        protected new readonly int numOfLocomotives;
        protected new int numOfWagons;
        protected new int numOfSeatsPerWagon;
        private new int seats;
        private new string name;

        int NumOfBusinessWagons
        {
            get => numOfBusinessWagons;
            set
            {
                numOfBusinessWagons = (value > 0) ? _ = value : _ = 4;
                RefreshSeats();
            }
        }
        int NumOfSeatsPerBusinessW
        {
            get => numOfSeatsPerBusinessW;
            set 
            {
                if (value > 0 && value < 99)
                {
                    if (value > 9) numOfBusinessWagons = value;
                    else numOfBusinessWagons = value * 10;
                }
                else numOfBusinessWagons = 48;
                RefreshSeats();
            }
        }
        int NumOfDefaultWagons
        {
            get => numOfDefaultWagons;
            set
            {
                numOfDefaultWagons = (value > 0) ? _ = value : _ = 4;
                RefreshSeats();
            }
        }
        int NumOfSeatsPerDefaultW
        {
            get => NumOfSeatsPerDefaultW;
            set
            {
                if (value > 0 && value < 99)
                {
                    if (value > 9) NumOfSeatsPerDefaultW = value;
                    else NumOfSeatsPerDefaultW = value * 10;
                }
                else NumOfSeatsPerDefaultW = 64;
                RefreshSeats();
            }
        }

        public override int NumOfWagons
        {
            get => numOfWagons;
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

        public new int Seats { get => seats; }

        private void RefreshSeats()
        {
            seats = numOfSeatsPerBusinessW * numOfBusinessWagons + numOfSeatsPerDefaultW * numOfDefaultWagons;
            numOfSeatsPerWagon = (int)Math.Round((double)(numOfSeatsPerBusinessW + numOfSeatsPerDefaultW) / 2, MidpointRounding.AwayFromZero);
        }
        public new string Name { get => name; }
        private void RefreshName ()
        {
            name = $"{type} экспресс {routeNum}-{numOfLocomotives}-{numOfWagons}";
        }

        public Express() 
        {
            numOfBusinessWagons = rnd.Next(4, 8);
            numOfDefaultWagons = rnd.Next(4, 12);
            numOfSeatsPerBusinessW = 48;
            numOfSeatsPerDefaultW = 64;
            type = "пассажирский";
            numOfLocomotives = 2;
            numOfSeatsPerWagon = (int)Math.Round((double)(numOfSeatsPerBusinessW + numOfSeatsPerDefaultW)/2, MidpointRounding.AwayFromZero);
            seats = numOfSeatsPerBusinessW * numOfBusinessWagons + numOfSeatsPerDefaultW * numOfDefaultWagons;
            numOfWagons = numOfBusinessWagons + numOfDefaultWagons;
            wghtOfLocomotive = rnd.Next(20 - 40) * 10;
            wghtOfWagon = rnd.Next(10, 20) * 10;
            routeNum = rnd.Next(700, 890);
            weight = numOfWagons * wghtOfWagon + numOfLocomotives * wghtOfLocomotive;
        }
        public Express(int routeID, int numOfBW, int numOfSPerBW, int numOfDW, int numOfSPerDW, int wghtOfW, int wghtOfL)
        {
            RouteNum = routeID;
            NumOfBusinessWagons = numOfBW;
            NumOfSeatsPerBusinessW = numOfSPerBW;
            NumOfDefaultWagons = numOfDW;
            NumOfSeatsPerDefaultW = numOfSPerDW;
            WghtOfLocomotive = wghtOfL;
            WghtOfWagon = wghtOfW;
        }
        public Express (Express express)
        {
            numOfBusinessWagons = express.numOfBusinessWagons;
            numOfDefaultWagons = express.numOfDefaultWagons;
            numOfSeatsPerBusinessW = express.numOfSeatsPerBusinessW;
            numOfSeatsPerDefaultW = express.numOfSeatsPerDefaultW;
            type = "пассажирский";
            numOfLocomotives = 2;
            numOfSeatsPerWagon = express.numOfSeatsPerWagon;
            routeNum = express.routeNum;
            numOfWagons = express.numOfWagons;
            wghtOfLocomotive = express.wghtOfLocomotive;
            wghtOfWagon = express.wghtOfWagon;
            weight = express.weight;
            seats =express.Seats;
        }
        public new object Clone()
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
            return name == v.Name && weight == v.Weight;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override int CompareTo(object obj)
        {
            return string.Compare(name, ((Express)obj).name);
        }
    }
}
