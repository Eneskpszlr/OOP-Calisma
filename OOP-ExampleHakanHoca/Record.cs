using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ExampleHakanHoca
{
    public abstract class Record
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime CreatedDate { get; } = DateTime.Now;

        public override string ToString()
        {
            return $"Id: {Id} Created Date: {CreatedDate} ";
        }
    }
}
