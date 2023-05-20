using DPA.shopping.DOMIAN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.shopping.DOMIAN.Core.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Favorite>> GetAll();
        Task<Favorite> GetById(int id);
        Task<bool> Insert(Favorite favorite);
        Task<bool> Update(Favorite favorite);
    }
}
