using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<Room> _roomRepository;

        public ReservationService(IRepository<Reservation> reservationRepository, IRepository<Room> roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }
        public void CancelReservation(Guid reservationId)
        {
            var existReservation = _reservationRepository.GetById(reservationId);
            if (existReservation == null)
            {
                Console.WriteLine("Rezervasyonunuz zaten bulunmamaktadır.");
            }
            else
            {
                _reservationRepository.Delete(reservationId);
                var room = _roomRepository.GetById(existReservation.RoomId);
                room.IsAvailable = true;
                Console.WriteLine("Rezervasyonunuz başarıyla silindi.");
            }
        }
        public void GetAvailableRooms(Guid roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            var existRoom = _roomRepository.GetById(roomId);
            if (existRoom == null)
            {
                Console.WriteLine("Böyle bir oda bulunmamaktadır.");
            }
            if (!existRoom.IsAvailable)
            {
                Console.WriteLine("Oda rezervasyon için uygun değil.");
            }
            else
            {
                var availableRooms = _roomRepository.GetAll().Where(room => room.IsAvailable == true).ToList();
                if (availableRooms.Count == 0)
                {
                    Console.WriteLine("Uygun oda bulunmamaktadır.");
                }
                else
                {
                    Console.WriteLine("Uygun odalar:");
                    foreach (var room in availableRooms)
                    {
                        Console.WriteLine($"{room.RoomId} - {room.RoomType} - {room.Price} TL");
                    }
                }
            }
        }
    }
}
