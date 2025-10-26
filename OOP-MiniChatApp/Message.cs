using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_MiniChatApp
{
    public class Message : Record
    {
        private string _content;

        public Message(string content, Guid senderId, Guid receiverId)
        {
            Content = content;
            SenderId = senderId;
            ReceiverId = receiverId;
            IsRead = false;
        }
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    value = "#";
                _content = value;
            }
        }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public bool IsRead { get; set; }
    }
}
