using System;

namespace TwinkleRestaurant.Models
{
    public class Table
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; } // "available" or "booked"
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
    }
}
