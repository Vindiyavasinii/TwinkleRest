using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.Repository
{
    public class adminRepository
    {
        private readonly List<admin> _admins = new List<admin>
        {
        new admin { Id = 1, Email = "admin@example.com", Password = "admin123" }
        // Add more admin accounts as needed
    };

        public admin Login(string email, string password)
        {
            return _admins.FirstOrDefault(a => a.Email == email && a.Password == password);
        }
    }
}
