﻿using OpTepaLavash.Pages.OrderDetails;

namespace OpTepaLavash.Pages
{
    public class OrderDetailPage
    {
        public static async Task OrderDetailPageRunAsync()
        {
            Console.Clear();
            Console.Write("1. Buyurtmalar ro'yxati \n" +
                          "2. Buyurtma ro'yxati \n" +
                          "3. Buyurtma qo'shish \n" +
                          "4. Buyurtmani yangilash \n" +
                          "5. Buyurtmani o'chirish \n" +
                          "0. Bosh minu \n");

            var choose = Console.ReadLine();
            if (choose == "1")
            {
                await ReadAllPage.ReadAllPageAsync();
            }
            else if (choose == "2")
            {
                await ReadPage.ReadPageAsync();
            }
            else if (choose == "3")
            {
                await CreatePage.CreatePageAsync();
            }
            else if (choose == "4")
            {
                await UpdatePage.UpdatePageRunAsync();
            }
            else if (choose == "5")
            {
                await DeletePage.DeletePageRunAsync();
            }
            else if (choose == "0")
            {
                await MainPage.MainPageRunAsync();
            }
            else
            {
                Helper.HelperMessage.Error("Xata belgi kiritdingiz");
                Thread.Sleep(3000);
                Console.Clear();
                await MainPage.MainPageRunAsync();
            }
        }
    }
}
