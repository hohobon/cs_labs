using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    public class Express: Train
    {
        double ticketCost;
        readonly new string type;
        int numOfBusinessSeats;
        int numOfDefaultSeats;
        readonly new int numOfLocomotives;
        readonly new int numOfWagons;

        double TicketCost
        {
            get => ticketCost;
            set
            {
                if (value > 0) ticketCost = value;
                else ticketCost = 100;
            }
        }
        int NumOfBusinessSeats
        {
            get => numOfBusinessSeats;
            set => numOfBusinessSeats = (value > 40) ? _ = value : _ = 40;
        }
        int NumOfDefaultSeats
        {
            get => numOfDefaultSeats;
            set => numOfDefaultSeats = (value > 40) ? _ = value : _ = 40;
        }


        public Express() 
        {
            numOfBusinessSeats = rnd.Next(4, 8) * 10;
            numOfDefaultSeats = rnd.Next(4, 12) * 10;
            ticketCost = 100 - Math.Round(rnd.NextDouble(), 2) * (-400);
            type = "пассажирский";
            numOfLocomotives = 2;
            numOfSeatsPerWagon = 10 * rnd.Next(20, 50);
            seats = numOfBusinessSeats + numOfDefaultSeats;
            numOfWagons = (int)Math.Round((Double)seats / numOfSeatsPerWagon, MidpointRounding.AwayFromZero); 
            wghtOfLocomotive = rnd.Next(40 - 60);
            wghtOfWagon = rnd.Next(10, 20) * 10;
            routeNum = rnd.Next(700, 890);
            weight = numOfWagons * wghtOfWagon + numOfLocomotives * wghtOfLocomotive;
            name = $"{type} экспресс {routeNum}-{numOfLocomotives}-{numOfWagons}";
        }
    }
}
