using ConsoleTables;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;
using OpTepaLavash.Pages.Clients;
using OpTepaLavash.Repositories;

namespace OpTepaLavash.Pages.Employees
{
    public class UpdatePage
    {
        public static async Task UpdatePageRunAsync()
        {
            ConsoleTable consoleTable = new ConsoleTable("Id", "FirstName", "LastName", "Age", "PhoneNumber", "Email: ", "Gender", "Descreption");

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


        lebel1:
            Console.Write("Hodim Id: ");
            Employee employee2 = new Employee();
            int Id = int.Parse(Console.ReadLine()!);
            var employee1 = await employeeRepository.GetAsync(Id);
            if (employee1.Id == Id)
            {
                Console.WriteLine("<=========>  Hodim malumotlarini yangilash  <=========>");
                Console.Write("Hodim ismi: ");
                employee1.FirstName = Console.ReadLine()!;

                Console.Write("Hodim familiyasi: ");
                employee1.LastName = Console.ReadLine()!;

                Console.Write("Yoshi: ");
                employee1.Age = int.Parse(Console.ReadLine()!);

                Console.WriteLine("Telefon raqam: ");
                employee1.PhoneNumber = Console.ReadLine()!;

                Console.WriteLine("Email: ");
                employee1.Email = Console.ReadLine()!;

                Console.WriteLine("0. Erkak  <=====>  1. Ayol");
                int gender = int.Parse(Console.ReadLine()!);
                if (gender == 0)
                {
                    employee1.Gender = Enum.Gender.Male;
                }
                else
                {
                    employee1.Gender = Enum.Gender.Female;
                }

                Console.WriteLine("Qisqacha tarif: ");
                employee1.Description = Console.ReadLine()!;


                await employeeRepository.UpdateAsync(Id, employee1);

                Helper.HelperMessage.Successfully("Successfully");
            }

            Console.WriteLine("0. Back 1. Break");
            string choose = Console.ReadLine()!;
            if (choose == "0") await ClientPage.ClientPageRunAsync();
            else if (choose == "1") Helper.HelperMessage.Successfully("Thank you for attention");
            else Helper.HelperMessage.Error("Xatto belgi kiritdingiz");
            Thread.Sleep(2000);
            goto lebel1;



        }
    }
}
