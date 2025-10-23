using BusinessObjects;
using HoangTranManhDungWPF.ViewModels.Base;
using HoangTranManhDungWPF.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoangTranManhDungWPF.ViewModels.Customer
{
    public class CustomerWindowViewModel : ViewModelBase
    {
        public ProfileViewModel ProfileVM { get; set; }

        public BookingHistoryViewModel BookingHistoryVM { get; set; }

        public CustomerWindowViewModel(BusinessObjects.Customer loggedInCustomer)
        {
            ProfileVM = new ProfileViewModel(loggedInCustomer);
            BookingHistoryVM = new BookingHistoryViewModel(loggedInCustomer);
        }
    }
}
