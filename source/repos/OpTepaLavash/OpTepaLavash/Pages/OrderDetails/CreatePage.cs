using DotLiquid.Tags;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;
using OpTepaLavash.Pages.Employees;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.OrderDetails
{
    public class CreatePage
    {
        public static async Task CreatePageAsync()
        {
            OrderDetail orderDetail = new OrderDetail();

            IOrderDetailRepository orderDetailRepository = new OrderDetailRepository();
            Console.Clear();
            Console.WriteLine("<=========> Qo'shimcha buyurtma qo'shish  <=========>");
        lebel:

            Console.Write("Buyurtma nomi: ");
            orderDetail.ProductId = int.Parse(Console.ReadLine()!);

            Console.Write("Buyurtma id: ");
            orderDetail.OrderId = int.Parse(Console.ReadLine()!);



  

            await orderDetailRepository.CreateAsync(orderDetail);

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
