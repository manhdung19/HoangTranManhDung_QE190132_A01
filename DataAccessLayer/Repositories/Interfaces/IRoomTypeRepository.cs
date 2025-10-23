using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IRoomTypeRepository
    {
        List<RoomType> GetRoomTypes();
        RoomType GetRoomTypeById(int id);
    }
}
