using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVehicle
{
    internal class Sort
    {
        public class SortByWeigh : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                Vehicle v1 = (Vehicle)x;
                Vehicle v2 = (Vehicle)y;
                if (v1.Weight > v2.Weight) return 1;
                if (v1.Weight < v2.Weight) return -1;
                return 0;
            }
        }
        public class SortByName : IComparer
        {
            int IComparer.Compare(object x, object y)
            {
                return string.Compare(((Vehicle)x).Name, ((Vehicle)y).Name);
            }
        }
    }
}
