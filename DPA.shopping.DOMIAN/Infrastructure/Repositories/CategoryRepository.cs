using DPA.shopping.DOMIAN.Core.Entities;
using DPA.shopping.DOMIAN.Core.Interfaces;
using DPA.shopping.DOMIAN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.shopping.DOMIAN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreDbContext _dbContext;

        public CategoryRepository(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;

        }

        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _dbContext
                            .Category
                            .Where(x => x.Id == id)
                            .FirstOrDefaultAsync();
            if (category == null)
                return false;

            _dbContext.Category.Remove(category);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var result = await _dbContext.Category.ToListAsync();
            return result;
        }

        public async Task<Category> GetById(int id)
        {
            var result = await _dbContext
                .Category
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}
