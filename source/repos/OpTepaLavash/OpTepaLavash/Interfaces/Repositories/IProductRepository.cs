using OpTepaLavash.Interfaces.Common;
using OpTepaLavash.Models;

namespace OpTepaLavash.Interfaces.Repositories
{
    public interface IProductRepository : ICreateable<Product>, IReadable<Product>,
        IDeleteable<Product>, IUpdateable<Product>
    {
    }
}
