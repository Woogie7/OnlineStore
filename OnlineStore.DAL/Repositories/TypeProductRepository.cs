using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Repositories
{
    public class TypeProductRepository : IBaseRepository<TypeProduct>
    {
        private readonly ApplicationDBContext _db;
        public TypeProductRepository(ApplicationDBContext dBContext)
        {
            _db = dBContext;
        }

        public Task Create(TypeProduct entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(TypeProduct entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TypeProduct>> GetAll()
        {
            return await _db.TypeProducts.ToListAsync();
        }

        public async Task<TypeProduct> GetById(int id)
        {
            return await _db.TypeProducts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<TypeProduct> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<TypeProduct> Update(TypeProduct entity)
        {
            throw new NotImplementedException();
        }
    }
}
