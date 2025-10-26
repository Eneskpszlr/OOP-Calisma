using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public class MessageServices : IMessageServices
    {
        private Repository<Message> messageList = new Repository<Message>();
        public void GetListMessage(List<Message> list)
        {
            foreach (var message in list)
            {
                Console.WriteLine("\nMesajlarınız: " + message);
            }
        }
        public void ReadMessage(Guid receiverId)
        {
            var messages = messageList.GetAll().Where(m => m.ReceiverId == receiverId).ToList();
            if (messages.Count == 0)
                Console.WriteLine("Mesajınız bulunmamaktadır.");
            Console.WriteLine("Gelen mesajlar:");
            foreach (var item in messages)
            {
                Console.WriteLine($"Gönderilme zamanı: {item.CreatedDate} {item.Content} {item.SenderId}");
            }
        }
        public void ReplyMessage(Guid senderId, Guid receiverId, string content)
        {
            SendMessage(senderId, receiverId, $"(Cevap): {content}");
        }
        public void SendMessage(Guid senderId, Guid receiverId, string content)
        {
            var message = new Message(senderId, receiverId, content)
            {
                SenderId = senderId,
                ReceiverId = receiverId
            };
            messageList.Add(message);
            Console.WriteLine("Mesaj başarıyla gönderildi.");
        }
    }
}
