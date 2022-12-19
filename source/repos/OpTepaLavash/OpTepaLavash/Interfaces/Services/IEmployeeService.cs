using OpTepaLavash.Models;

namespace OpTepaLavash.Interfaces.Services
{
    public interface IEmployeeService
    {

        public Task<Employee> GetAsync(int id);

        public Task<IEnumerable<Employee>> GetAllAsync();

    }
}
