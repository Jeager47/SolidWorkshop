using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidWorkshop.Models;

namespace SolidWorkshop.Repositories
{
    public interface IOrderRepository
    {
        void Save(IEnumerable<Order> orders);
        IEnumerable<Order> Load();
    }

}
