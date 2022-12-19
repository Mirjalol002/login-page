using ConsoleTables;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Clients
{

    public class ReadAllPage
    {
        public static async Task ReadAllPageRunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "Foydalanuvchi ismi", "Foydalanuvhci familiyasi", "Yoshi", "Jinsi");
            IClientRepository clientRepository = new ClientRepository();
            //IClientService clientService = new ClientService();

            var clients = await clientRepository.GetAllAsync();
            foreach (var client in clients)
            {
                consoleTable.AddRow(client.Id,
                    client.FirstName, client.LastName, client.Age, client.Gender);
            }
            consoleTable.Write();

            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Console.WriteLine("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz");
            Thread.Sleep(2000);

        }
    }
}
