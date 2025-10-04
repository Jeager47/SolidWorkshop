using SolidWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorkshop.Repositories
{
    public class FileOrderRepository : IOrderRepository
    {
        private readonly string _filePath = "orders.txt";

        public void Save(IEnumerable<Order> orders)
        {
            try
            {
                using var sw = new StreamWriter(_filePath);
                foreach (var o in orders)
                {
                    sw.WriteLine($"{o.Id};{o.CustomerName};{o.Total}");
                    foreach (var it in o.Items)
                        sw.WriteLine($"  {it.ProductName};{it.Quantity};{it.UnitPrice}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar pedidos: " + ex.Message);
            }
        }

        public IEnumerable<Order> Load()
        {
            var list = new List<Order>();
            if (!File.Exists(_filePath))
                return list;

            // (simplificado) — luego podemos mejorar la carga real
            return list;
        }
    }
}
