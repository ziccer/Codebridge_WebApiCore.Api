using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Codebridge_WebApiCore.Data.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> AllAsync();
        Task Add(TEntity entity);
        Task Delete(TEntity entity);
        Task Update(TEntity entity);
        Task<TEntity> FindById(string id);
    }
}
