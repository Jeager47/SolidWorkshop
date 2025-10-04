using SolidWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorkshop.Strategies
{
    public interface IPriceCalculator
    {
        decimal CalculateTotal(List<OrderItem> items);
    }
}
