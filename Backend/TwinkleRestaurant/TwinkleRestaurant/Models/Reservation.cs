namespace TwinkleRestaurant.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
    }
}
