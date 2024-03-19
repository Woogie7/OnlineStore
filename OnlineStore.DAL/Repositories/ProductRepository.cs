using Microsoft.EntityFrameworkCore;
using OnlineStore.DAL.Interfaces;
using OnlineStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DAL.Repositories
{
	public class ProductRepository : IBaseRepository<Product>
	{
		private readonly ApplicationDBContext _db;
		public ProductRepository(ApplicationDBContext dBContext) 
		{
			_db = dBContext;
		}
		public async Task Create(Product entity)
		{
			await _db.product.AddAsync(entity);
			await _db.SaveChangesAsync();
		}

		public async Task Delete(Product entity)
		{
			_db.product.Remove(entity);
			await _db.SaveChangesAsync();
		}

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _db.product.Include(x => x.TypeProduct).ToListAsync();
        }

        public async Task<Product> GetById(int id)
        {
			return await _db.product
                .Include(p => p.TypeProduct)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<Product> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Update(Product entity)
		{
			_db.product.Update(entity);
			await _db.SaveChangesAsync();

			return entity;
		}

	}
}
