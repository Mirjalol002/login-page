using Microsoft.EntityFrameworkCore;
using OpTepaLavash.DB_Constants;
using OpTepaLavash.Interfaces.Repositories;
using OpTepaLavash.Models;

namespace OpTepaLavash.Repositories
{
    public class ClientRepository : IClientRepository
    {
        AppDbContext appDbContext = new AppDbContext();

        Client clients = new Client();



        public async Task<bool> CreateAsync(Client obj)
        {
            await appDbContext.Clients.AddAsync(obj);
            await appDbContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var client = await appDbContext.Clients.FindAsync(id);
            appDbContext.Clients.Remove(client!);
            await appDbContext.SaveChangesAsync();

            return true;
        }

#pragma warning disable
        public async Task<IQueryable<Client>> GetAllAsync()
            => appDbContext.Clients;
        public async Task<Client> GetAsync(int id)
            => await appDbContext.Clients.FindAsync(id)!;
#pragma warning restore
        public async Task<bool> UpdateAsync(int id, Client obj)
        {
            var client = await appDbContext.Clients.FindAsync(id);
            if (client is null)
                return false;
            client.Id = id;
            client.Age = obj.Age;
            client.FirstName = obj.FirstName;
            client.LastName = obj.LastName;
            client.Gender = obj.Gender;
            

            appDbContext.Clients.Update(client);
            await appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
