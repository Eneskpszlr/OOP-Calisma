using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MiniChatApp
{
    public class MessageServices : IMessageServices
    {
        private Repository<Message> messageList = new Repository<Message>();
        public void GetAllMessages()
        {
            var messages = messageList.GetAll();
            if (messages.Count == 0)
            {
                Console.WriteLine("Hiç mesaj yok.");
            }

            foreach (var m in messages)
            {
                Console.WriteLine($"{m.CreatedDate} - {m.SenderId} -> {m.ReceiverId}: {m.Content}");
            }
        }
        public void ReadMessage(Guid receiverId)
        {
            var messages = messageList.GetAll().Where(x =>  x.ReceiverId == receiverId).ToList();
            if (messages.Count == 0)
            {
                Console.WriteLine("Mesaj kutunuz boş.");
                return;
            }

            Console.WriteLine("=== Gelen Mesajlar ===");
            foreach (var msg in messages)
            {
                msg.IsRead = true;
                Console.WriteLine($"Tarih: {msg.CreatedDate} | Gönderen: {msg.SenderId} | İçerik: {msg.Content} | Okundu: {msg.IsRead}");
            }
        }
        public void ReplyMessage(Guid senderId, Guid receiverId, string content)
        {
            SendMessage(senderId, receiverId, $"cevap: {content}");
        }
        public void SendMessage(Guid senderId, Guid receiverId, string content)
        {
            Message newMessage = new Message(content, senderId, receiverId);
            messageList.Add(newMessage);
            Console.WriteLine("Mesaj başarıyla gönderildi.");
        }
        public void RemoveMessage(Guid id)
        {
            var existing = messageList.GetAll().FirstOrDefault(x => x.Id == id);
            if (existing == null)
            {
                Console.WriteLine("Silinecek mesaj bulunamadı.");
                return;
            }

            messageList.Delete(existing);
            Console.WriteLine("Mesaj başarıyla silindi.");
        }

        public void UpdateMessage(Guid id, string newContent)
        {
            var existing = messageList.GetAll().FirstOrDefault(y => y.Id == id);
            if (existing == null)
            {
                Console.WriteLine("Güncellenecek mesaj bulunamadı.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newContent))
            {
                Console.WriteLine("Yeni içerik boş olamaz.");
                return;
            }

            existing.Content = newContent;
            Console.WriteLine("Mesaj başarıyla güncellendi.");
        }

        public void NotReadOnlyMessages(Guid receiverId)
        {
            // 1. Kullanıcıya gelen ve henüz okunmamış mesajları filtrele
            var messages = messageList.GetAll().Where(x => x.ReceiverId == receiverId && x.IsRead == false).ToList();

            // 2. Hiç mesaj yoksa kullanıcıya bilgi ver
            if (messages.Count == 0)
            {
                Console.WriteLine("Okunmamış mesajınız bulunmamaktadır.");
                return;
            }

            // 3. Mesajları listele
            Console.WriteLine("=== Okunmamış Mesajlar ===");
            foreach (var m in messages)
            {
                Console.WriteLine($"{m.CreatedDate} - Gönderen: {m.SenderId} -> Mesaj: {m.Content}");
            }
        }
    }
}
