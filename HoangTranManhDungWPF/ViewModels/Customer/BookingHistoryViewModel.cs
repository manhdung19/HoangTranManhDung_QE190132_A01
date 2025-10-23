using Services.Services.Implementations;
using Services.Services.Interfaces;
using BusinessObjects;
using HoangTranManhDungWPF.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoangTranManhDungWPF.ViewModels.Customer
{
    public class BookingHistoryViewModel : ViewModelBase
    {
        private readonly IBookingService _bookingService;
        private readonly int _customerId;

        private ObservableCollection<BookingReservation> _bookingHistory;
        public ObservableCollection<BookingReservation> BookingHistory
        {
            get => _bookingHistory;
            set => SetProperty(ref _bookingHistory, value);
        }

        public BookingHistoryViewModel(BusinessObjects.Customer loggedInCustomer)
        {
            _bookingService = new BookingService();
            _customerId = loggedInCustomer.CustomerID;

            LoadBookingHistory();
        }

        private void LoadBookingHistory()
        {
            var history = _bookingService.GetBookingsByCustomerId(_customerId);
            BookingHistory = new ObservableCollection<BookingReservation>(history);
        }
    }
}
