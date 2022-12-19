using OpTepaLavash.Interfaces.Common;
using OpTepaLavash.Models;

namespace OpTepaLavash.Interfaces.Repositories
{
    public interface IClientRepository : ICreateable<Client>, IReadable<Client>, IDeleteable<Client>, IUpdateable<Client>
    {
    }
}
