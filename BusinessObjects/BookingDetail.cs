using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class BookingDetail
    {
        public int BookingReservationID { get; set; }
        [NotMapped]
        public virtual BookingReservation BookingReservation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal? ActualPrice { get; set; }
        public int RoomID { get; set; }
        [NotMapped]
        public virtual RoomInformation RoomInformation { get; set; }
    }
}
