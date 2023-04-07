using ENTGS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
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
        protected int engineСapacity;
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
        static string[] Models = 
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

    }
}
