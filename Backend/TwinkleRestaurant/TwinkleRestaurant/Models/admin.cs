using System.ComponentModel.DataAnnotations;

namespace TwinkleRestaurant.Models
{
    public class admin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
