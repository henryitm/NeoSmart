using NeoSmart.Shared.Responses;

namespace NeoSmart.Backend.Services
{
    public interface IApiService
    {
        Task<Response<T>> GetAsync<T>(string servicePrefix, string controller);
    }
}
