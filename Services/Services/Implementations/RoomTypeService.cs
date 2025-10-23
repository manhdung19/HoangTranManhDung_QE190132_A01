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
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;

        public RoomTypeService()
        {
            _roomTypeRepository = RoomTypeRepository.Instance;
        }

        public List<RoomType> GetRoomTypes()
        {
            return _roomTypeRepository.GetRoomTypes();
        }
    }
}
