using ConsoleTables;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Clients
{
#pragma warning disable
    public class UpdatePage
    {
        public static async Task UpdatePageRunAsync()
        {
            ConsoleTable consoleTable1 = new ConsoleTable("Id", "Foydalanuvhci ismi", "Foydalanuvchi familiyasi", "Yoshi", "Jinsi");

            IClientRepository clientRepository1 = new ClientRepository();
            var clientss = await clientRepository1.GetAllAsync();
            int gender = int.Parse(Console.ReadLine()!);
            foreach (var clientt in clientss)
            {
                string gender2;
                if (clientt.Gender == Enum.Gender.Male)
                {
                    gender2 = "Mele";
                }
                else
                {
                    gender2 = "Female";
                }
                consoleTable1.AddRow(clientt.Id, clientt.FirstName, clientt.LastName, clientt.Age, gender);
            }

            consoleTable1.Write();


            Client client = new Client();
            IClientRepository clientRepository = new ClientRepository();
            int Id = int.Parse(Console.ReadLine());
            var clients = await clientRepository.GetAsync(Id);

            if (clients.Id != 0)
            {
                Console.WriteLine("<=========>  Foydalanuvchi malumotlarini yangilash  <=========>");
                Console.Write("Foydalanuvchi ismi: ");
                client.FirstName = Console.ReadLine();

                Console.Write("Foydalanuvchi familiyasi: ");
                client.LastName = Console.ReadLine();

                Console.Write("Yoshi: ");
                client.Age = int.Parse(Console.ReadLine()!);

                Console.WriteLine("0. Erkak  <=====>  1. Ayol");
                int gender1 = int.Parse(Console.ReadLine());
                if (gender1 == 0)
                {
                    client.Gender = Enum.Gender.Male;
                }
                else
                {
                    client.Gender = Enum.Gender.Female;
                }

                await clientRepository.UpdateAsync(Id, client);

                Helper.HelperMessage.Successfully("Successfully");
            }
            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz!");
                Thread.Sleep(1000);
                await UpdatePage.UpdatePageRunAsync();
            }

        }
    }
}
