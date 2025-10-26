using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public interface IMessageServices
    {
        void SendMessage(Guid senderID, Guid receiverId, string content);
        void ReplyMessage(Guid senderID, Guid receiverId, string content);
        void GetListMessage(List<Message> list);
        void ReadMessage(Guid receiverId);
    }
}
