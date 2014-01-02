using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
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

        //Ophalen Tickets
        public static ObservableCollection<Ticket> GetTickets()
        {
            //Database openen en gegevens ophalen
            ObservableCollection<Ticket> tickets = new ObservableCollection<Ticket>();
            DbDataReader reader = Database.GetData("SELECT * FROM Tickets");

            //Rij overlopen en nieuw Ticket aanmaken.
            foreach (DbDataRecord record in reader)
            {
                Ticket ticket = Create(record);
                tickets.Add(ticket);
            }
            return tickets;
        }

        //Aanmaken van Ticket (alle gegevens invullen)
        private static Ticket Create(IDataRecord record)
        {
            return new Ticket()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Ticketholder = record["TicketEigenaar"].ToString(),
                TicketholderEmail = record["TicketEmail"].ToString(),
                TicketType = TicketType.GetTicketType(Convert.ToInt32(record["TicketTypeID"].ToString())),
                Amount = Convert.ToInt32(record["Aantal"].ToString())
            };
        }

        //Het leesbaar maken voor de listbox
        public override string ToString()
        {
            string result = "";
            result += "Houder: " + Ticketholder + " - ";
            result += "Type: " + TicketType + " - ";
            result += "Aantal: " + Amount;
            return result;
        }
    }
}
