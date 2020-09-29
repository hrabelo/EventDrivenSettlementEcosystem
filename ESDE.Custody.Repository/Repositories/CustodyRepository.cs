using ESDE.Custody.Domain.Interfaces;
using ESDE.Custody.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ESDE.Custody.Repository.Repositories
{
    public class CustodyRepository : ICustodyRepository
    {
        private readonly CustodyDbContext _context;
        public CustodyRepository(CustodyDbContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public async Task<IEnumerable<Domain.Entities.Custody>> GetAll()
        {
            var custodies = await _context.Custodies.ToListAsync();
            return custodies;
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
