using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MiniChatApp
{
    public interface IMessageServices
    {
        void SendMessage(Guid senderId, Guid receiverId, string content);
        void ReplyMessage(Guid senderId, Guid receiverId, string content);

        void ReadMessage(Guid receiverId);
        void GetAllMessages();

        void RemoveMessage(Guid id);

        void UpdateMessage(Guid id, string newContent);

        void NotReadOnlyMessages(Guid receiverId);
    }
}
