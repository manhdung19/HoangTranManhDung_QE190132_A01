using BusinessObjects;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer.Repositories.Interfaces;

namespace DataAccessLayer.Repositories.Implementations
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        //Singleton Patter
        private static RoomTypeRepository instance = null;
        private static readonly object instanceLock = new object();
        private RoomTypeRepository() { }
        public static RoomTypeRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomTypeRepository();
                    }
                    return instance;
                }
            }
        }
        public List<RoomType> GetRoomTypes()
        {
            return MockDatabase.RoomTypes.ToList();
        }
        public RoomType GetRoomTypeById(int id)
        {
            return MockDatabase.RoomTypes.FirstOrDefault(rt => rt.RoomTypeID == id);
        }
    }
}
