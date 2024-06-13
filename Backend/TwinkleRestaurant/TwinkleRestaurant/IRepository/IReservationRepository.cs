using TwinkleRestaurant.Models;

namespace TwinkleRestaurant.IRepository
{


        public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAllReservations();
        Reservation GetReservationById(int id);
        Reservation BookReservation(Reservation reservation);
    }

}

