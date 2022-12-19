using ConsoleTables;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Employees
{
    public class ReadAllPage
    {
        public static async Task ReadAllPageRunAsync()
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

            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await EmployeePage.EmployeePageRunAsync();
            else if (choose == "1") Console.WriteLine("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz"); 
            Thread.Sleep(2000); 

        }
    }
}
