using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models
{
    public class RoleModel
    {
        public string Name { get; set; }

        public bool Update { get; set; } = false;

        public bool Create { get; set; } = false;

        public bool Delete { get; set; } = false;

        public bool Resolve { get; set; } = false;
    }
}
