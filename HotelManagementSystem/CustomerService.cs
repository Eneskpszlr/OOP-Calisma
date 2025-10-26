using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<Customer> _customerRepository;
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<Room> _roomRepository;

        public CustomerService(IRepository<Customer> customerRepository, IRepository<Reservation> reservationRepository, IRepository<Room> roomRepository)
        {
            _customerRepository = customerRepository;
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }
        public void CreateReservation(Guid customerId, Guid roomId, DateTime checkInDate, DateTime checkOutDate)
        {
            var existCustomer = _customerRepository.GetById(customerId);
            if (existCustomer == null)
            {
                Console.WriteLine("Böyle bir müşteri bulunmamaktadır. Önce kayıt olun.");
            }
            var existRoom = _roomRepository.GetById(roomId);
            if (existRoom == null)
            {
                Console.WriteLine("Böyle bir oda bulunmamaktadır.");
            }
            if (!existRoom.IsAvailable)
            {
                Console.WriteLine("Oda rezervasyona uygun değildir.");
            }
            else
            {   
                Reservation newReservation = new Reservation(customerId, roomId, checkInDate, checkOutDate);
                _reservationRepository.Add(newReservation);
                existRoom.MarkAsUnavailable();
                Console.WriteLine("Rezervasyonunuz başarıyla yapıldı.");
            }
        }

        public void GetCustomerReservations(Guid customerId)
        {
            var existCustomer = _customerRepository.GetById(customerId);
            if (existCustomer == null)
            {
                Console.WriteLine("Böyle bir müşteri bulunmamaktadır. Önce kayıt olun.");
                return;
            }
            var customerReservations = _reservationRepository.GetAll().Where(r => r.CustomerId == customerId).ToList();
            if (customerReservations.Count == 0)
            {
                Console.WriteLine("Müşterinin rezervasyonu bulunmamaktadır.");
            }
            else
            {
                Console.WriteLine("Müşterinin rezervasyonları:");
                foreach (var reservation in customerReservations)
                {
                    Console.WriteLine($"Rezervasyon ID: {reservation.ReservationId} | Oda ID: {reservation.RoomId} | Giriş: {reservation.CheckInTime} | Çıkış: {reservation.CheckOutTime}");
                }
            }
        }

        public string RegisterCustomer(Customer customer)
        {
            var existCustomer = _customerRepository.GetById(customer.Id);
            if( existCustomer != null)
            {
                return  "Böyle bir müşteri zaten kayıtlı.";
            }
            else if(existCustomer.Email == customer.Email)
            {
                return "Email zaten kayıtlı yeni bir email giriniz.";
            }
            else
            {
                _customerRepository.Add(customer);
                return "Müşteri başarıyla kaydedildi.";
            }
        }
    }
}
