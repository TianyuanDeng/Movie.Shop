using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
    public class PurchaseRepository: EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        { 

        }

        public async Task<IEnumerable<Purchase>> GetAllPurchaseById(int id)
        {
            var pur = _dbContext.Purchases.Where(p => p.UserId == id).ToList();

            return pur;
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchases(int pageSize = 30, int pageIndex = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Purchase>> GetAllPurchasesByMovie(int movieId, int pageSize = 30, int pageIndex = 0)
        {
            throw new NotImplementedException();
        }
    }
}
