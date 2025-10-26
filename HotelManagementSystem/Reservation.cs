using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public class Reservation
    {
        public Reservation(Guid customerId, Guid roomId, DateTime checkInTime, DateTime checkOutTime)
        {
            ReservationId = Guid.NewGuid();
            CustomerId = customerId;
            RoomId = roomId;
            CheckInTime = checkInTime;
            CheckOutTime = checkOutTime;
        }

        public Guid ReservationId { get; }
        public Guid CustomerId { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CheckInTime { get; set; }
        public DateTime CheckOutTime { get; set; }
    }
}
