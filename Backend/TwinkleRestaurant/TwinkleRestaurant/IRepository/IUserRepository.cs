using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.IRepository
{
    public interface IUserRepository
    {
            void Add(User user);
            User GetById(int UId);
            User Login(string email, string password);
        }

    }

