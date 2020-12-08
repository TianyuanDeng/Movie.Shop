using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Core.RepositoryInterfaces
{
    public interface IReviewRepository : IAsyncRepository<Review>
    {
        Task<Review> AddReview(int mid, int uid);
    }
}
