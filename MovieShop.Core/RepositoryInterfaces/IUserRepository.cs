using MovieShop.Core.Entities;
using System.Threading.Tasks;

namespace MovieShop.Core.RepositoryInterfaces
{
     public interface IUserRepository: IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
