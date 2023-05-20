using DPA.shopping.DOMIAN.Core.Entities;
using DPA.shopping.DOMIAN.Core.Interfaces;
using DPA.shopping.DOMIAN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.shopping.DOMIAN.Infrastructure.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly StoreDbContext _dbContext;
        public FavoriteRepository(StoreDbContext dbContext)
        {
        
            _dbContext = dbContext;
        
        }
        public async Task<bool> Delete(int id)
        {
            var favorite =await _dbContext.Favorite.Where(f => f.Id == id).FirstOrDefaultAsync();
            if (favorite == null) { return false; }
            _dbContext.Favorite.Remove(favorite);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<IEnumerable<Favorite>> GetAll()
        {
            var result = await _dbContext.Favorite.ToListAsync();
            return result;
        }

        public async Task<Favorite> GetById(int id)
        {
            var result = await _dbContext.Favorite.Where(f => f.Id == id).FirstOrDefaultAsync();
            return result;

        }

        public async Task<bool> Insert(Favorite favorite)
        {
           await _dbContext.Favorite.AddAsync(favorite);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Favorite favorite)
        {
            _dbContext.Favorite.Update(favorite);
            var rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
