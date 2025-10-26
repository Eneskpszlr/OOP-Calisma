using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public interface IReservationService
    {
        void GetAvailableRooms(Guid roomId, DateTime checkInDate,  DateTime checkOutDate);
        void CancelReservation(Guid reservationId);
    }
}
