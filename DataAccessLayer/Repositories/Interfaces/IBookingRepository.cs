using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        List<BookingReservation> GetBookingsByCustomerId(int customerId);
        List<BookingReservation> GetBookingsByDateRange(DateTime startDate, DateTime endDate);
    }
}
