using SolidWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorkshop.Strategies
{
    public class ReducedTaxCalculator : IPriceCalculator
    {
        public decimal CalculateTotal(List<OrderItem> items)
        {
            decimal subtotal = 0;
            foreach (var it in items)
                subtotal += it.Quantity * it.UnitPrice;

            decimal tax = subtotal * 0.10m; // IVA reducido
            decimal total = subtotal + tax;

            if (subtotal > 200)
                total -= 20; // descuento mayor

            return total;
        }
    }
}
