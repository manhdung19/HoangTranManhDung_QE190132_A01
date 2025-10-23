using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Services.Interfaces
{
    public interface IBookingService
    {
        List<BookingReservation> GetBookingsByCustomerId(int customerId);
        List<BookingReservation> GetBookingsReport(DateTime startDate, DateTime endDate);
    }
}
