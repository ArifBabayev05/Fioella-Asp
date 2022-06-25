using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Base;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Repositories
{
	public class ProductRepository : IBaseRepository<Product>
	{
		private readonly AppDbContext _context;

        public ProductRepository( AppDbContext context)
        {
			_context = context;
        }

		public async Task<Category> Get(int? id)
        {
			if (id is null)
			{
				throw new ArgumentNullException("Id");
			}
			var data = await _context.Categories.Where(n => n.Id == id)
											  .FirstOrDefaultAsync();

			if (data is null)
			{
				throw new NullReferenceException("Data Could Not Be Found!");
			}
			return data;
        }
		public async Task<List<Product>> GetAll()
		{
			var data = await _context.Categories.Where(n => !n.IsDeleted)
											  .Include(n => n.Image)
											  .Include(n => n.Category)
											  .OrderByDescending(n => n.CreatedDate)
											  .ToListAsync();

            if (data is null)
            {
				throw new NullReferenceException();
            }
			return data;
		}
		public async Task Create(Product entity)
        {
			entity.CreatedDate = DateTime.Now;

			await _context.Products.AddAsync(entity);
			await _context.SaveChangesAsync();

		}
		public async Task Update( int id ,Product entity)
		{
			var dbEntity =await Get(id);
			if (dbEntity is null)
			{
				throw new NullReferenceException("Product is null!");
			}


			dbEntity.Name = entity.Name;
			dbEntity.Count = entity.Count;
			dbEntity.Price = entity.Price;
			dbEntity.CategoryId = entity.CategoryId;
			dbEntity.ImageId = entity.ImageId;
			dbEntity.UpdatedDate = DateTime.Now; 


			await _context.SaveChangesAsync();
			
		}
		public async Task Delete(int? id)
		{
            if (id is null)
            {
				throw new ArgumentNullException();
            }
			var data = await Get(id);
            if (data is null)
            {
				throw new NullReferenceException();
            }

			data.IsDeleted = true;

			//await Update(id, data);
			await _context.SaveChangesAsync();
		}

        Task<Product> IBaseRepository<Product>.Get(int? id)
        {
            throw new NotImplementedException();
        }
    }
}

