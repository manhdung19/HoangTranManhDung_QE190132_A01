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
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService()
        {
            _roomRepository = RoomRepository.Instance;
        }

        public void AddRoom(RoomInformation room)
        {
            _roomRepository.AddRoom(room);
        }

        public void DeleteRoom(int id)
        {
            _roomRepository.DeleteRoom(id);
        }

        public List<RoomInformation> GetRooms()
        {
            return _roomRepository.GetRooms();
        }

        public List<RoomInformation> SearchRooms(string keyword)
        {
            var allRooms = _roomRepository.GetRooms();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return allRooms;
            }

            string lowerKeyword = keyword.ToLower();
            return allRooms
                .Where(r => r.RoomNumber.ToLower().Contains(lowerKeyword) ||
                            r.RoomDescription.ToLower().Contains(lowerKeyword))
                .ToList();
        }

        public void UpdateRoom(RoomInformation room)
        {
            _roomRepository.UpdateRoom(room);
        }
    }
}
