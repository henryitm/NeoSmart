using NeoSmart.Shared.Responses;

namespace NeoSmart.Backend.Intertfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<Response<T>> GetAsync(int id);

        Task<Response<IEnumerable<T>>> GetAsync();

        Task<Response<T>> AddAsync(T entity);

        Task<Response<T>> DeleteAsync(int id);

        Task<Response<T>> UpdateAsync(T entity);
    }
}
