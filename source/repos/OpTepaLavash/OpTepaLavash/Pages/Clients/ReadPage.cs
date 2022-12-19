using ConsoleTables;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Clients
{
    public class ReadPage
    {
        public static async Task ReadPageRunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Foydalanuvhci ismi", "Foydalanuvchi familiyasi", "Yoshi", "Jinsi");
            IClientRepository clientRepository = new ClientRepository();


            var clientViewModels = await clientRepository.GetAllAsync();
            foreach (var client in clientViewModels)
            {
                consoleTable.AddRow(client.Id,
                    client.FirstName, client.LastName, client.Age, client.Gender);
            }
            consoleTable.Write();



        lebel:

            Console.Write("Id: ");

            int id = int.Parse(Console.ReadLine()!);


            Console.Clear();

            ConsoleTable consoleTable1 = new ConsoleTable("Id", "Foydalanuvhci ismi", "Foydalanuvchi familiyasi", "Yoshi", "Jinsi");


            foreach (var client in clientViewModels)
            {
                if (client.Id == id)
                {
                    consoleTable1.AddRow(client.Id,
                        client.FirstName, client.LastName, client.Age, client.Gender);
                }
            }
            Console.Clear();
            consoleTable1.Write();


            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfully("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz");
            Thread.Sleep(2000);
            goto lebel;
        }
    }
}