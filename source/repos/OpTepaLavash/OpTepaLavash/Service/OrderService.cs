using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Repositories;
using OpTepaLavash.ViewModels;

namespace OpTepaLavash.Service
{
    public class OrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IEmployeeRepository _employeeRepository;
        public OrderService()
        {
            _orderRepository = new OrderRepository();
            _employeeRepository = new EmployeeRepository();
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {
            var orders = await _orderRepository.GetAllAsync();
            var orderViewModels = new List<OrderViewModel>();
            foreach (var order in orders)
            {
                var orderViewModel = (OrderViewModel)order;
                orderViewModel.EmployeeName = (await _employeeRepository.GetAsync(order.EmployeeId)).FirstName;
                orderViewModels.Add(orderViewModel);
            }
            return orderViewModels;
        }

        public async Task<OrderViewModel> GetAsync(int id)
        {
            var order = await _orderRepository.GetAsync(id);

            var orderViewModel = (OrderViewModel)order;

            orderViewModel.EmployeeName = (await _employeeRepository.GetAsync(order.EmployeeId)).FirstName;

            return orderViewModel;
        }
    }
}
