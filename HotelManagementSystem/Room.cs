using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public enum RoomType
    {
        Standart, Suit
    }
    public class Room
    {
        public Room(RoomType roomType, decimal price, bool ısAvailable)
        {
            RoomId = Guid.NewGuid();
            RoomType = roomType;
            Price = price;
            IsAvailable = ısAvailable;
        }

        public Guid RoomId { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; } = true;
        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        public void MarkAsUnavailable()
        {
            IsAvailable = false;
        }

        public void MarkAsAvailable()
        {
            IsAvailable = true;
        }
    }
}
