using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using Services.Services.Interfaces;

namespace Services.Services.Implementations
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService()
        {
            _bookingRepository = BookingRepository.Instance;
        }

        public List<BookingReservation> GetBookingsByCustomerId(int customerId)
        {
            return _bookingRepository.GetBookingsByCustomerId(customerId)
                                     .OrderByDescending(b => b.BookingDate)
                                     .ToList();
        }

        public List<BookingReservation> GetBookingsReport(DateTime startDate, DateTime endDate)
        {
            return _bookingRepository.GetBookingsByDateRange(startDate, endDate)
                                     .OrderByDescending(b => b.TotalPrice)
                                     .ToList();
        }
    }
}
