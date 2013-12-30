using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Festival.model
{
    class Ticket
    {
        public int ID { get; set; }
        public string Ticketholder { get; set; }
        public string TicketholderEmail { get; set; }
        public TicketType TicketType { get; set; }
        public int Amount { get; set; }
    }
}
