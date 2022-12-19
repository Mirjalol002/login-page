﻿using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Clients
{
#pragma warning disable
    public class CreatePage
    {
        public static async Task CreatePageRunAsync()
        {
            Client clients = new Client();
            Console.Clear();
            Console.WriteLine("<=========>  Foydalanuvchi qo'shish  <=========>");

        lebel:
            Console.Write("Foydalanuvchi Ismi: ");
            clients.FirstName = Console.ReadLine();

            Console.Write("Foydalanuvchi Familiyasi: ");
            clients.LastName = Console.ReadLine();

            Console.Write("Foydalanuvchi yoshi: ");
            clients.Age = int.Parse(Console.ReadLine()!);

            Console.WriteLine("0. Erkak  <=======> 1. Ayol");
            int gender = int.Parse(Console.ReadLine());

            if (gender == 0)
            {
                clients.Gender = Enum.Gender.Male;
                Helper.HelperMessage.Successfully("Successfully");
            }
            else if (gender == 1)
            {
                clients.Gender = Enum.Gender.Female;
                Helper.HelperMessage.Successfully("Successfully");
            }
            else
            {
                Helper.HelperMessage.Error("Xato belgi kiritdingiz");
                Thread.Sleep(3000);
                Console.Clear();
                await CreatePage.CreatePageRunAsync();
            }

            IClientRepository clientRepository = new ClientRepository();
            await clientRepository.CreateAsync(clients);

            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine();
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfully("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz");
            Thread.Sleep(1000);
            goto lebel;

        }
    }
}
