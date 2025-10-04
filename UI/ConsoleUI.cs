using SolidWorkshop.Models;
using SolidWorkshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidWorkshop.UI
{
    public class ConsoleUI
    {
        private readonly OrderService _service;

        public ConsoleUI(OrderService service)
        {
            _service = service;
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n--- SISTEMA DE PEDIDOS (SRP) ---");
                Console.WriteLine("1. Crear pedido");
                Console.WriteLine("2. Listar pedidos");
                Console.WriteLine("3. Salir");
                Console.Write("Elija: ");
                var key = Console.ReadLine();

                switch (key)
                {
                    case "1":
                        CreateOrder();
                        break;
                    case "2":
                        ListOrders();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }

        private void CreateOrder()
        {
            Console.Write("Nombre del cliente: ");
            var customer = Console.ReadLine();

            var items = new List<OrderItem>();
            while (true)
            {
                Console.Write("Producto (enter para terminar): ");
                var prod = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(prod)) break;

                Console.Write("Cantidad: ");
                var qtyStr = Console.ReadLine();
                int qty = int.TryParse(qtyStr, out int q) ? q : 1;

                Console.Write("Precio unitario: ");
                var priceStr = Console.ReadLine();
                decimal price = decimal.TryParse(priceStr, out decimal p) ? p : 0;

                items.Add(new OrderItem { ProductName = prod, Quantity = qty, UnitPrice = price });
            }

            try
            {
                var order = _service.CreateOrder(customer, items);
                Console.WriteLine($"Pedido {order.Id} creado. Total: {order.Total:C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ListOrders()
        {
            foreach (var o in _service.GetOrders())
                Console.WriteLine($"[{o.Id}] {o.CustomerName} - Total: {o.Total:C}");
        }
    }
}
