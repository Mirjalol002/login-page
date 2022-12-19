using ConsoleTables;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Clients
{
    public class DeletePage
    {
        public static async Task DeletePageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "Foydalanuvchi Ism", "Foydalanuvchi familiyasi", "Yoshi", "Telefon raqam", "Email", "Qisqacha tarif", "Jinsi");

            IEmployeeRepository employeeRepository = new EmployeeRepository();
            var employees = await employeeRepository.GetAllAsync();
            foreach (var employee in employees)
            {
                if (employee.Gender == 0)
                {
                    employee.Gender = Enum.Gender.Male;
                }
                else
                {
                    employee.Gender = Enum.Gender.Female;
                }


                consoleTable.AddRow(employee.Id, employee.FirstName, employee.LastName, employee.Age, employee.Gender);
            }

            consoleTable.Write();
        lebel:
            Console.Write("Id kiriting: ");
            int Id = int.Parse(Console.ReadLine()!);

            bool take = (employees.FirstOrDefault(x => x.Id == Id) != null);

            if (take)
            {
                await employeeRepository.DeleteAsync(Id);
                Helper.HelperMessage.Successfully("Successfully!");
            }

            else
            {
                Helper.HelperMessage.Error("Xatto belgi kiritdingiz!");
                await DeletePage.DeletePageRunAsync();
            }

            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfully("Thank you for attention");
            else Helper.HelperMessage.Error("Xattoo belgi kiritdingiz");
            Thread.Sleep(1000);
            goto lebel;
        }
    }
}
