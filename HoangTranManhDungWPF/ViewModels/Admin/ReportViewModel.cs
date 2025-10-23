using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Services.Services.Implementations;
using Services.Services.Interfaces;
using HoangTranManhDungWPF.ViewModels.Base;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace HoangTranManhDungWPF.ViewModels.Admin
{
    public class ReportViewModel : ViewModelBase
    {
        private readonly IBookingService _bookingService;

        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        private ObservableCollection<BookingReservation> _bookings;
        public ObservableCollection<BookingReservation> Bookings
        {
            get => _bookings;
            set
            {
                SetProperty(ref _bookings, value);
                CalculateTotalRevenue();
            }
        }

        private decimal _totalRevenue;
        public decimal TotalRevenue
        {
            get => _totalRevenue;
            set => SetProperty(ref _totalRevenue, value);
        }

        public ICommand GenerateReportCommand { get; }

        public ReportViewModel()
        {
            _bookingService = new BookingService();
            GenerateReportCommand = new RelayCommand(GenerateReport, CanGenerateReport);

            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;
        }

        private bool CanGenerateReport()
        {
            return StartDate <= EndDate;
        }

        private void GenerateReport()
        {
            if (!CanGenerateReport())
            {
                MessageBox.Show("Start Date must be earlier than or equal to End Date.", "Date Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var reportData = _bookingService.GetBookingsReport(StartDate, EndDate);
            Bookings = new ObservableCollection<BookingReservation>(reportData);
        }

        private void CalculateTotalRevenue()
        {
            if (Bookings == null)
            {
                TotalRevenue = 0;
                return;
            }

            TotalRevenue = Bookings.Sum(b => b.TotalPrice ?? 0);
        }
    }
}
