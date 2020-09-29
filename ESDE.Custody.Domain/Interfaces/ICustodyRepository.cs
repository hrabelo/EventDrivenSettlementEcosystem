using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESDE.Custody.Domain.Interfaces
{
    public interface ICustodyRepository
    {
        void Add<T>(T entity) where T : class;

        void Remove<T>(T entity) where T : class;

        Task<bool> SaveAll();

        Task<IEnumerable<Entities.Custody>> GetAll();
    }
}
