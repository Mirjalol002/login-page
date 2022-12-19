using DemoApp.Domain.Models;
using System.Linq.Expressions;

namespace DemoApp.Data.Interfaces
{
    public interface ICarRepository
    {
        public Task CreateAsync(Car car);

        public Task<IQueryable<Car>> WhereAsync(Expression<Func<Car, bool>> predicate);

        public Task<Car> FirstOrDefoultAsync(Expression<Func<Car, bool>> predicate);

        public Task<Car> UpdateAsync(long id, Car car);

        public Task<Car> DeleteAsync(long id);

    }
}
