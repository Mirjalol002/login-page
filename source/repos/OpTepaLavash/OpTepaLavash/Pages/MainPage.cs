using OpTepaLavash.Pages.Clients;
using OpTepaLavash.Pages.Employees;
using OpTepaLavash.Pages.Products;

namespace OpTepaLavash.Pages
{
    public class MainPage
    {

        public static async Task MainPageRunAsync()
        {
            Console.Write("1. Maxsulotlar \n" +
                          "2. Buyurtmalar \n" +
                          "3. Xodimlar \n" +
                          "4. Mijozlar \n" +
                          "5.  \n" +
                          "6. ");
            string input = Console.ReadLine()!;

            if (input == "1")
            {
                await ProductPage.ProductPageRunAsync();
            }
            else if (input == "2")
            {
                await OrderPage.OrderPageAsync();
            }
            else if (input == "3")
            {
                await EmployeePage.EmployeePageRunAsync();
            }
            else if (input == "4")
            {
                await ClientPage.ClientPageRunAsync();
            }

        }


    }
}
