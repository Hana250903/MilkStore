using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class OrderDetailBusiness
    {
        public double CalculateTotalPrice(double price, int quantity)
        {
            return price * quantity;
        }
    }
}
