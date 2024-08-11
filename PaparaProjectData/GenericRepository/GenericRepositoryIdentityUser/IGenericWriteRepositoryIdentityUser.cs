using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.GenericRepository.GenericRepositoryIdentityUser
{
    public interface IGenericWriteRepositoryIdentityUser<TEntity> where TEntity : class
    {
        Task Save();
        Task<TEntity> Insert(TEntity entity);
        void Update(TEntity entity);
        Task Delete(string Id);
    }
}
