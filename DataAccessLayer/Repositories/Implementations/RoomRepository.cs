using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class RoomRepository : IRoomRepository
    {
        //Singleton Pattern
        private static RoomRepository instance = null;
        private static readonly object instanceLock = new object();
        private RoomRepository() { }
        public static RoomRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomRepository();
                    }
                    return instance;
                }
            }
        }
        public List<RoomInformation> GetRooms()
        {
            var rooms = MockDatabase.Rooms.Where(r => r.RoomStatus == 1).ToList();
            foreach (var room in rooms)
            {
                room.RoomType = MockDatabase.RoomTypes.FirstOrDefault(rt => rt.RoomTypeID == room.RoomTypeID);
            }
            return rooms;
        }

        public RoomInformation GetRoomById(int id)
        {
            var room = MockDatabase.Rooms.FirstOrDefault(r => r.RoomID == id && r.RoomStatus == 1);
            if (room != null)
            {
                room.RoomType = MockDatabase.RoomTypes.FirstOrDefault(rt => rt.RoomTypeID == room.RoomTypeID);
            }
            return room;
        }
        public void AddRoom(RoomInformation room)
        {
            int newId = MockDatabase.Rooms.Max(r => r.RoomID) + 1;
            room.RoomID = newId;
            room.RoomStatus = 1;
            MockDatabase.Rooms.Add(room);
        }
        public void UpdateRoom(RoomInformation room)
        {
            RoomInformation existingRoom = MockDatabase.Rooms.FirstOrDefault(r => r.RoomID == room.RoomID);
            if (existingRoom != null)
            {
                existingRoom.RoomNumber = room.RoomNumber;
                existingRoom.RoomDescription = room.RoomDescription;
                existingRoom.RoomMaxCapacity = room.RoomMaxCapacity;
                existingRoom.RoomPricePerDate = room.RoomPricePerDate;
                existingRoom.RoomTypeID = room.RoomTypeID;
                existingRoom.RoomStatus = room.RoomStatus;
            }
        }
        public void DeleteRoom(int id)
        {
            RoomInformation room = MockDatabase.Rooms.FirstOrDefault(r => r.RoomID == id);
            if (room != null)
            {
                room.RoomStatus = 2;
            }
        }
    }
}