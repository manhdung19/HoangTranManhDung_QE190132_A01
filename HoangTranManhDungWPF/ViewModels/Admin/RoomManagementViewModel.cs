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
using System.Windows;
using System.Windows.Input;
using HoangTranManhDungWPF.Views.Admin;

namespace HoangTranManhDungWPF.ViewModels.Admin
{
    public class RoomManagementViewModel : ViewModelBase
    {
        private readonly IRoomService _roomService;

        private ObservableCollection<RoomInformation> _rooms;
        public ObservableCollection<RoomInformation> Rooms
        {
            get => _rooms;
            set => SetProperty(ref _rooms, value);
        }

        private RoomInformation _selectedRoom;
        public RoomInformation SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                SetProperty(ref _selectedRoom, value);
            }
        }

        private string _searchText;
        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public ICommand LoadRoomsCommand { get; }
        public ICommand AddRoomCommand { get; }
        public ICommand UpdateRoomCommand { get; }
        public ICommand DeleteRoomCommand { get; }
        public ICommand SearchCommand { get; }

        public RoomManagementViewModel()
        {
            _roomService = new RoomService();
            LoadRoomsCommand = new RelayCommand(LoadRooms);
            AddRoomCommand = new RelayCommand(AddRoom);
            UpdateRoomCommand = new RelayCommand(UpdateRoom, CanModify);
            DeleteRoomCommand = new RelayCommand(DeleteRoom, CanModify);
            SearchCommand = new RelayCommand(SearchRooms);

            LoadRooms();
        }

        private void LoadRooms()
        {
            SearchText = string.Empty;
            Rooms = new ObservableCollection<RoomInformation>(_roomService.GetRooms());
        }

        private void SearchRooms()
        {
            Rooms = new ObservableCollection<RoomInformation>(_roomService.SearchRooms(SearchText));
        }

        private bool CanModify()
        {
            return SelectedRoom != null;
        }

        private void DeleteRoom()
        {
            var result = MessageBox.Show($"Are you sure you want to delete Room {SelectedRoom.RoomNumber}?",
                                         "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                _roomService.DeleteRoom(SelectedRoom.RoomID);
                LoadRooms();
            }
        }

        private void AddRoom()
        {
            RoomDialog dialog = new RoomDialog(null);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _roomService.AddRoom(dialog.Room);
                LoadRooms();
            }
        }

        private void UpdateRoom()
        {
            // Tạo bản sao
            var roomToUpdate = new RoomInformation
            {
                RoomID = SelectedRoom.RoomID,
                RoomNumber = SelectedRoom.RoomNumber,
                RoomDescription = SelectedRoom.RoomDescription,
                RoomMaxCapacity = SelectedRoom.RoomMaxCapacity,
                RoomPricePerDate = SelectedRoom.RoomPricePerDate,
                RoomTypeID = SelectedRoom.RoomTypeID,
                RoomStatus = SelectedRoom.RoomStatus
            };

            RoomDialog dialog = new RoomDialog(roomToUpdate);
            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                _roomService.UpdateRoom(dialog.Room);
                LoadRooms();
            }
        }
    }
}
