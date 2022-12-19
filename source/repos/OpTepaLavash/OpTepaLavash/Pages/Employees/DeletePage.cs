using ConsoleTables;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Employees
{
    public class DeletePage
    {
        public static async Task DeletePageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "FirstName", "LastName", "Age", "PhoneNumber", "Email", "Gender", "Descraption");

            IEmployeeRepository employeeRepository = new EmployeeRepository();
            var employees = await employeeRepository.GetAllAsync();
            foreach (var employee in employees)
            {
                string gender;
                if (employee.Gender == Enum.Gender.Male)
                {
                    gender = "Erkak";
                }
                else
                {
                    gender = "Ayol";
                }
                consoleTable.AddRow(employee.Id, employee.FirstName, employee.LastName, employee.Age, employee.PhoneNumber, employee.Email, gender, employee.Description);
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
            if (choose == "0") await EmployeePage.EmployeePageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfully("Thank you for attention");
            else Helper.HelperMessage.Error("Xattoo belgi kiritdingiz");
            Thread.Sleep(1000);
            goto lebel;

        }
    }
}
