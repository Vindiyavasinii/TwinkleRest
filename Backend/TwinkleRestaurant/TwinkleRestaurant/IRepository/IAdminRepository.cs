using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.NewFolder
{
   
        public interface IAdminRepository
        {
            admin Login(string email, string password);
        }

    }

