using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public interface ICustomerService
    {
        string RegisterCustomer(Customer customer);
        void GetCustomerReservations(Guid customerId);
        void CreateReservation(Guid customerId, Guid roomId, DateTime checkInDate, DateTime checkOutDate);
    }
}
