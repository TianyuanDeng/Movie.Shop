using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
    public class ReviewRepository: EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Review> AddReview(int mid, int uid)
        {
            throw new NotImplementedException();
        }
    }
}
