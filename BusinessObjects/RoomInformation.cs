﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class RoomInformation
    {
        public int RoomID { get; set; }
        public string RoomNumber { get; set; }
        public string? RoomDescription { get; set; }
        public int? RoomMaxCapacity { get; set; }
        public byte? RoomStatus { get; set; }
        public decimal? RoomPricePerDate { get; set; }
        public int RoomTypeID { get; set; }

        [NotMapped]
        public virtual RoomType RoomType { get; set; }
    }
}
