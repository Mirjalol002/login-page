using OpTepaLavash.ViewModels;

namespace OpTepaLavash.Interfaces.Services
{
    public interface IOrderService
    {
        public Task<OrderViewModel> GetAsync(int id);
        public Task<IEnumerable<OrderViewModel>> GetAllAsync();
    }
}
