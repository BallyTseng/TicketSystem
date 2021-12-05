using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class TicketModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string Summary { get; set; }

        public string Description { get; set; }

        public bool Resolve { get; set; } = false;

        public DateTime CreateTime = DateTime.Now;

        public DateTime UpdateTime = DateTime.Now;
    }
}
