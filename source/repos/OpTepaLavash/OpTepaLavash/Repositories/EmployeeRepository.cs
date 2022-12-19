using Microsoft.EntityFrameworkCore;
using OpTepaLavash.DB_Constants;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;

namespace OpTepaLavash.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        AppDbContext appDbContext = new AppDbContext();

        Employee employees = new Employee();

        public async Task<bool> CreateAsync(Employee obj)
        {
            await appDbContext.Employees.AddAsync(obj);
            await appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await appDbContext.Employees.FindAsync(id);
            appDbContext.Employees.Remove(employee!);
            await appDbContext.SaveChangesAsync();
            return true;

        }
#pragma warning disable

        public async Task<IQueryable<Employee>> GetAllAsync() =>  appDbContext.Employees;

        public async Task<Employee> GetAsync(int id) => await appDbContext.Employees.FindAsync(id);

# pragma warning restore
        public async Task<bool> UpdateAsync(int id, Employee obj)
        {
            var employee = await appDbContext.Employees.FindAsync(id);
            if (employee is null)
                return false;

            employee.Id= obj.Id;
            employee.FirstName= obj.FirstName;
            employee.LastName= obj.LastName;
            employee.Age= obj.Age;
            employee.PhoneNumber= obj.PhoneNumber;
            employee.Email= obj.Email;
            employee.Gender = obj.Gender;
            employee.Description= obj.Description;
            appDbContext.Employees.Update(employee!);
            await appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
