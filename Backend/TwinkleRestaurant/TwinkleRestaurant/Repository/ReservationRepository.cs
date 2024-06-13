using TwinkleRestaurant.IRepository;
using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.Repository
{
 

        public class ReservationRepository : IReservationRepository
    {
        private readonly List<Reservation> _reservations = new List<Reservation>();

        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        public Reservation GetReservationById(int id)
        {
            return _reservations.FirstOrDefault(r => r.Id == id);
        }

        public Reservation BookReservation(Reservation reservation)
        {
            reservation.Id = _reservations.Count + 1;
            _reservations.Add(reservation);
            return reservation;
        }
    }

}

