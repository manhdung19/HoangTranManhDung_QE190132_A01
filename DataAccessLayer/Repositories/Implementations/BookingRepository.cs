using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class BookingRepository : IBookingRepository
    {
        //Singleton Pattern
        private static BookingRepository instance = null;
        private static readonly object instanceLock = new object();
        private BookingRepository() { }
        public static BookingRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookingRepository();
                    }
                    return instance;
                }
            }
        }
        public List<BookingReservation> GetBookingsByCustomerId(int customerId)
        {
            var bookings = MockDatabase.BookingReservations
                            .Where(br => br.CustomerID == customerId)
                            .ToList();
            foreach (var booking in bookings)
            {
                booking.Customer = MockDatabase.Customers.FirstOrDefault(c => c.CustomerID == booking.CustomerID);
                booking.BookingDetails = MockDatabase.BookingDetails
                                        .Where(bd => bd.BookingReservationID == booking.BookingReservationID)
                                        .ToList();
                foreach (var detail in booking.BookingDetails)
                {
                    detail.RoomInformation = MockDatabase.Rooms.FirstOrDefault(r => r.RoomID == detail.RoomID);
                }
            }
            return bookings;
        }

        public List<BookingReservation> GetBookingsByDateRange(DateTime startDate, DateTime endDate)
        {
            var detailsInRange = MockDatabase.BookingDetails
                .Where(bd => bd.StartDate >= startDate && bd.EndDate <= endDate)
                .ToList();

            var reservationIds = detailsInRange.Select(bd => bd.BookingReservationID).Distinct();

            var bookings = MockDatabase.BookingReservations
                .Where(br => reservationIds.Contains(br.BookingReservationID))
                .ToList();

            foreach (var booking in bookings)
            {
                booking.Customer = MockDatabase.Customers.FirstOrDefault(c => c.CustomerID == booking.CustomerID);
                booking.BookingDetails = detailsInRange
                                        .Where(bd => bd.BookingReservationID == booking.BookingReservationID)
                                        .ToList();
            }

            return bookings;
        }
    }
}
