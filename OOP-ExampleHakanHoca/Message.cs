using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public class Message : Record
    {
		private string _content;

        public Message(Guid senderId, Guid receiverId, string content)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Content = content;
        }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content
		{
			get { return _content; }
			set 
			{
				if(string.IsNullOrEmpty(value))
					throw new ArgumentNullException("Boş mesaj gönderilemez.");
				if (value.Length < 1)
                    _content = "*";
                else
					_content = value;

			}
		}
        public override string ToString()
        {
			return $" SenderId: {SenderId} ReceiverId{ReceiverId} Content: {Content}";
        }
	}
}
