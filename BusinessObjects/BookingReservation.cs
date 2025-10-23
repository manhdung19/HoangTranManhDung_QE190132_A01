using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects
{
    public class BookingReservation
    {
        public int BookingReservationID { get; set; }
        public DateTime? BookingDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public byte? BookingStatus { get; set; }
        public int CustomerID { get; set; }
        [NotMapped]
        public virtual Customer Customer { get; set; }
        [NotMapped]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; } = new List<BookingDetail>();
    }
}
