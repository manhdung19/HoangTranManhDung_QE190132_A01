using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services.Services.Interfaces
{
    public interface IRoomService
    {
        List<RoomInformation> GetRooms();
        void AddRoom(RoomInformation room);
        void UpdateRoom(RoomInformation room);
        void DeleteRoom(int id);
        List<RoomInformation> SearchRooms(string keyword);
    }
}
