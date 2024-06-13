using TwinkleRestaurant.IRepository;
using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.Repository
{
  

public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User user)
        {
            user.UId = _users.Count + 1; // Simulate auto-increment
            _users.Add(user);
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(u => u.UId == id);
        }

        public User Login(string email, string password)
        {
            return _users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
    }

}

