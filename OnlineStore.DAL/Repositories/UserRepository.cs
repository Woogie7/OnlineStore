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
		public class UserRepository : IBaseRepository<User>
		{
			private readonly ApplicationDBContext _db;

			public UserRepository(ApplicationDBContext db)
			{
				_db = db;
			}

			public async Task<IEnumerable<User>> GetAll()
			{
				return await _db.Users.ToListAsync();
			}

			public async Task Delete(User entity)
			{
				_db.Users.Remove(entity);
				await _db.SaveChangesAsync();
			}

			public async Task Create(User entity)
			{
				await _db.Users.AddAsync(entity);
				await _db.SaveChangesAsync();
			}

			public async Task<User> Update(User entity)
			{
				_db.Users.Update(entity);
				await _db.SaveChangesAsync();

				return entity;
			}

			public async Task<User> GetById(int id)
			{
				return await _db.Users.FirstOrDefaultAsync(u => u.Id == id);
			}

			public async Task<User> GetByName(string name)
			{
				return await _db.Users.FirstOrDefaultAsync(u => u.Name == name);
			}
		}
}
