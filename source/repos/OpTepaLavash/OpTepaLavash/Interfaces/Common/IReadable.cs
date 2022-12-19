namespace OpTepaLavash.Interfaces.Common
{
    public interface IReadable<T>
    {
        Task<IQueryable<T>> GetAllAsync();

        Task<T> GetAsync(int id);
    }
}
