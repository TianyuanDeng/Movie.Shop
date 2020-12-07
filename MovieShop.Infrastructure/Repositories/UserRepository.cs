using Microsoft.EntityFrameworkCore;
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
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
