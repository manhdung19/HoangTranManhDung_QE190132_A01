using Services.Services.Implementations;
using Services.Services.Interfaces;
using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HoangTranManhDungWPF.Views.Admin
{
    /// <summary>
    /// Interaction logic for RoomDialog.xaml
    /// </summary>
    public partial class RoomDialog : Window
    {
        public RoomInformation Room { get; private set; }
        public Visibility IDVisibility { get; private set; }

        private readonly IRoomTypeService _roomTypeService;

        public RoomDialog(RoomInformation room)
        {
            InitializeComponent();
            _roomTypeService = new RoomTypeService();

            LoadRoomTypes();

            if (room == null)
            {
                Room = new RoomInformation();
                this.Title = "Add New Room";
                IDVisibility = Visibility.Collapsed;
            }
            else
            {
                Room = room;
                this.Title = "Update Room";
                IDVisibility = Visibility.Visible;
            }

            this.DataContext = Room;
        }

        private void LoadRoomTypes()
        {
            var roomTypes = _roomTypeService.GetRoomTypes();
            RoomTypeComboBox.ItemsSource = roomTypes;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Room.RoomNumber) || Room.RoomTypeID == 0)
            {
                MessageBox.Show("Room Number and Room Type are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!int.TryParse(Room.RoomMaxCapacity.ToString(), out _) ||
                !decimal.TryParse(Room.RoomPricePerDate.ToString(), out _))
            {
                MessageBox.Show("Capacity must be a number and Price must be a decimal.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
