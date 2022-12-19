using DemoApp.Data.DbContexts;
using DemoApp.Data.Interfaces;
using DemoApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DemoApp.Data.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _dbContext;

        public CarRepository()
        {
            _dbContext = new AppDbContext();
        }
        public async Task CreateAsync(Car car)
        {
            if (car is not null)
            {
                await _dbContext.AddAsync(car);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Car> DeleteAsync(long id)
        {
            var car = await _dbContext.Cars.FindAsync(id);
            if (car is not null)
            {
                _dbContext.Cars.Remove(car);
                await _dbContext.SaveChangesAsync();

            }
            return car;

        }

        public async Task<Car> FirstOrDefoultAsync(Expression<Func<Car, bool>> predicate)
        {
            var car = await _dbContext.Cars.FirstOrDefaultAsync(predicate);
            return car!;
        }

        public async Task<Car> UpdateAsync(long id, Car car)
        {
            var oldCar = await _dbContext.Cars.FindAsync(id);

            if (oldCar is not null)
            {
                return _dbContext.Update(car).Entity;
                await _dbContext.SaveChangesAsync();

            }
            else
            {
                return oldCar!;
            }
        }

# pragma warning disable
        public async Task<IQueryable<Car>> WhereAsync(Expression<Func<Car, bool>> predicate)
        {
            return predicate == null ? _dbContext.Cars : _dbContext.Cars.Where(predicate);
        }
    }
}
