using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaparaProjectData.GenericRepository.GenericRepositoryIdentityUser
{
    public interface IGenericReadRepositoryIdentityUser<TEntity> where TEntity : class
    {
        Task Save();
        Task<TEntity?> GetById(string Id, params string[] includes);
        Task<List<TEntity>> GetAll();
    }
}
