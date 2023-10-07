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
	public class ProductRepository : IProductRepository
	{
		private readonly ApplicationDBContext _db;
		public ProductRepository(ApplicationDBContext dBContext) 
		{
			_db = dBContext;
		}
		public async Task<bool> CreateAsync(Product entity)
		{
			await _db.product.AddAsync(entity);
			await _db.SaveChangesAsync();

			return true;
		}

		public async Task<bool> Delete(Product entity)
		{
			_db.product.Remove(entity);
			await _db.SaveChangesAsync();
			return true;
		}

		public async Task<Product> Get(int id)
		{
			return await _db.product.FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<Product> GetByNameAsync(string name)
		{
			return await _db.product.FirstOrDefaultAsync(x => x.Name == name);
		}

		public async Task<List<Product>> Select()
		{
			return await _db.product.ToListAsync();
		}
	}
}
