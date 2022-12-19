using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;
using OpTepaLavash.Repositories;
using OpTepaLavash.ViewModels;

namespace OpTepaLavash.Pages.Orders
{
    public class CreatePage
    {
#pragma warning disable

        public static async Task CreatePageRunAsync()
        {
            Order order = new Order();
            OrderDetail orderDetail = new OrderDetail();
            OrderViewModel orderViewModel = new OrderViewModel();


            IEmployeeRepository employeeRepository = new EmployeeRepository();
            IOrderRepository orderRepository = new OrderRepository();
            IProductRepository productRepository = new ProductRepository();
            Console.Clear();
            Console.WriteLine("<=========> Qo'shimcha buyurtma qo'shish  <=========>");
        lebel:


            Console.Write("Buyurtma id: ");
            orderViewModel.Id = int.Parse(Console.ReadLine());


            Console.Write("TableNumber: ");
            orderViewModel.tableNumber = int.Parse(Console.ReadLine());

            Console.Write("ClientFirstName: ");
            orderViewModel.ClientName = Console.ReadLine();


            int productId = (await productRepository.GetAllAsync()).FirstOrDefault(x => x.Name.Equals(orderViewModel.ProductName)).Id;

            Console.Write("ProductCount: ");
            orderViewModel.Count = int.Parse(Console.ReadLine()!);

            orderViewModel.TotalSum = (await productRepository.GetAsync(productId)).Price * orderViewModel.Count;

            string employeeId = (await employeeRepository.GetAllAsync()).FirstOrDefault(x => x.FirstName.Equals(orderViewModel.EmployeeName))!.FirstName;
            orderViewModel.EmployeeName = employeeId;

            order.DateTime = DateTime.Now;


            await orderRepository.CreateAsync(orderViewModel);

            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await OrderDetailPage.OrderDetailPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfully("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz");
            Thread.Sleep(1000);
            goto lebel;
        }
    }
}
