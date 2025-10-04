using SolidWorkshop.Repositories;
using SolidWorkshop.Services;
using SolidWorkshop.Strategies;
using SolidWorkshop.UI;


namespace SolidWorkshop
{
    class Program
    {
        static void Main()
        {
            var repo = new FileOrderRepository();
            var calculator = new ReducedTaxCalculator();
            //var calculator = new DefaultPriceCalculator(); // nueva dependencia
            var service = new OrderService(repo, calculator);
            var ui = new ConsoleUI(service);
            ui.Run();
        }
    }
}