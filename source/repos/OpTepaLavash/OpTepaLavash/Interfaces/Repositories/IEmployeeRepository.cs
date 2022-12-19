using OpTepaLavash.Interfaces.Common;
using OpTepaLavash.Models;

namespace OpTepaLavash.Interfaces.Repositories
{
    public interface IEmployeeRepository : ICreateable<Employee>, IReadable<Employee>,
        IDeleteable<Employee>, IUpdateable<Employee>
    {
    }
}
