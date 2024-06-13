using System.ComponentModel.DataAnnotations;

namespace TwinkleRestaurant.Models
{
    public class User
    {
        [Key]
        public int UId { get; set; }

        [Required]
        public string UName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
    }

