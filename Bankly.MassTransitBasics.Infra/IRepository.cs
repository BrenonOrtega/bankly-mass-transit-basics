using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bankly.MassTransitBasics.Infra
{
    public interface IRepository<T>
    {
        Task AddAsync<V>(V storeKey, T entity);
        Task<T> GetOneAsync<V>(V storeKey);
    }
}