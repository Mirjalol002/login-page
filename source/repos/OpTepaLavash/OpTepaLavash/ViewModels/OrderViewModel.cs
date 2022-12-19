using OpTepaLavash.Models;

namespace OpTepaLavash.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public int tableNumber { get; set; }

        public string ClientName { get; set; } = string.Empty;

        public int TotalSum { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string ProductName { get; set; } = string.Empty;
        public int Count { get; set; }

        public int OrderId { get; set; }
        public DateTime DateTime { get; set; }

        public static explicit operator OrderViewModel(Order order)
        {
            return new OrderViewModel()
            {
                Id = order.Id,
               // tableNumber = order.TableNumber,
                ClientName = (order.Employee.FirstName + " " + order.Employee.LastName),
                TotalSum = order.TotalSum,
                EmployeeName = (order.Employee.FirstName + " " + order.Employee.LastName),
                DateTime = order.DateTime
            };
        }

        public static explicit operator OrderViewModel(OrderDetail orderDetail)
        {


  
            return new OrderViewModel()
            {
                Id = orderDetail.Id,
                ProductName = orderDetail.Product.Name,
                Count = orderDetail.Count,
                OrderId = orderDetail.OrderId,
                tableNumber = orderDetail.TableNamber
            };
        }
    }
}
