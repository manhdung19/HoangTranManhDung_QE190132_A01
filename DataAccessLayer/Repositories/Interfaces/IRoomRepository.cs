using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        List<RoomInformation> GetRooms();
        RoomInformation GetRoomById(int id);
        void AddRoom(RoomInformation room);
        void UpdateRoom(RoomInformation room);
        void DeleteRoom(int id);
    }
}
