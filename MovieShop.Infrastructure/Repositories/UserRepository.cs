using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace MovieShop.Infrastructure.Repositories
{
    public class UserRepository: EfRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        { 
           
        }

        public async Task<User> GetUserByEmail(string email) 
        {
            throw new NotImplementedException();
        }
    }
}
