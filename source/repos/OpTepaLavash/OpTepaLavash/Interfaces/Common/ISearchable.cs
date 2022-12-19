namespace OpTepaLavash.Interfaces.Common
{
    public interface ISearchable<T>
    {
        Task<IEnumerable<T>> SearchAsync(T obj);
    }
}
