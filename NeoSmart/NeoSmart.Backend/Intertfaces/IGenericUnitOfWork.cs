﻿using NeoSmart.Shared.Responses;


namespace NeoSmart.Backend.Intertfaces
{
    public interface IGenericUnitOfWork<T> where T : class
    {
        Task<Response<IEnumerable<T>>> GetAsync();

        Task<Response<T>> AddAsync(T model);

        Task<Response<T>> UpdateAsync(T model);

        Task<Response<T>> DeleteAsync(int id);

        Task<Response<T>> GetAsync(int id);
    }
}
