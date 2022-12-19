using DemoApp.Domain.Comman;
using DemoApp.Domain.Models;
using DemoApp.Service.Common.Util;
using DemoApp.Service.Common.Utils;
using DemoApp.Service.ViewModels;
using System.Linq.Expressions;

namespace DemoApp.Service.Interfaces
{
    public interface ICarService
    {
        public Task<PagedList<CarViewModel>> WhereAsync(PaginationParams @params, Expression<Func<Car, bool>> predicate = null!);


        public Task<BaseResult<CarViewModel>> GetAsync(Expression<Func<Car, bool>> predicate = null!);


        public Task<BaseResult<bool>> CreateAsync(Car car);


        public Task<BaseResult<bool>> UpdateAsync(long id, Car car);


        public Task<BaseResult<bool>> DeleteAsync(long id);
    }
}
