using ConsoleTables;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Pages.Clients;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Employees
{
    public class ReadPage
    {
        public static async Task ReadPageRunAsync()
        {
            Console.Clear();

            ConsoleTable consoleTable = new ConsoleTable("Id", "FirstName", "LastName", "Age", "PhoneNumber", "Email: ", "Gender", "Descriction");
            IEmployeeRepository employeeRepository = new EmployeeRepository();


            var employees = await employeeRepository.GetAllAsync();
            foreach (var employee in employees)
            {
                consoleTable.AddRow(employee.Id,
                    employee.FirstName, employee.LastName, employee.Age, employee.PhoneNumber, employee.Email, employee.Gender, employee.Description);
            }
            consoleTable.Write();




        lebel:
            Console.Write("Id: ");

            int id = int.Parse(Console.ReadLine()!);


            Console.Clear();

            ConsoleTable consoleTable1 = new ConsoleTable("Id", "FirstName", "LastName", "Age", "PhoneNumber", "Email: ", "Gender", "Descriction");


            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    consoleTable1.AddRow(employee.Id,
                        employee.FirstName, employee.LastName, employee.Age, employee.PhoneNumber, employee.Email, employee.Gender, employee.Description);
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
