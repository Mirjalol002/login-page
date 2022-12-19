using DemoApp.Data.Interfaces;
using DemoApp.Data.Repositories;
using DemoApp.Domain.Comman;
using DemoApp.Domain.Models;
using DemoApp.Service.Common.Util;
using DemoApp.Service.Common.Utils;
using DemoApp.Service.Interfaces;
using DemoApp.Service.ViewModels;
using System.Linq.Expressions;

namespace DemoApp.Service.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ImageManager _imageManager;

        public CarService()
        {
            _carRepository = new CarRepository();
            _imageManager = new ImageManager();
        }

        public async Task<BaseResult<bool>> CreateAsync(Car car)
        {
            var result = new BaseResult<bool>();
            if (!String.IsNullOrEmpty(car.ImagePath)) 
            {
                if (File.Exists(car.ImagePath))
                {
                    car.ImagePath = await _imageManager.ComposeAsync(car.ImagePath);
                }
                else
                {
                    result.isSuccesful = false;
                    result.ErrorMessage = "Image not found";
                    return result;
                }
            }
            await _carRepository.CreateAsync(car);
            result.isSuccesful = true;
            return result;
           
        }

        public Task<BaseResult<bool>> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<CarViewModel>> GetAsync(Expression<Func<Car, bool>> predicate = null!)
        {
            throw new NotImplementedException();
        }

        public Task<BaseResult<bool>> UpdateAsync(long id, Car car)
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<CarViewModel>> WhereAsync(PaginationParams @params,
            Expression<Func<Car, bool>> predicate = null!)
        {
            IQueryable<CarViewModel> quary = from entity in await _carRepository.WhereAsync(predicate)
                                             select new CarViewModel()
                                             {
                                                 Id = entity.Id,
                                                 Name = entity.Name,
                                                 Color = entity.Color,
                                                 ImageFullPath = entity.ImagePath,
                                                 Model = entity.Model,
                                                 MadeYear= entity.MadeYear,
                                                 Number= entity.Number,
                                                 ItemState= entity.ItemState,                                                 
                                             };
            var data = await PagedList<CarViewModel>.ToPagedListAsync(quary, @params.PageNumber, @params.PageSize);

            return data;

        }
    }
}
