using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public class Customer : Person
    {
        public Customer(string firstName, string lastName, string email) : base(firstName, lastName, email)
        {
        }
        public List<Reservation> ReservationHistory { get; set; } = new List<Reservation>();
    }
}
