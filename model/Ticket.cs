using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

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

        //Nieuw ticket toevoegen aan DB
        public static void Add(string houder, string email, string type, int aantal)
        {
            int typeID = TicketType.GetTicketID(type);
            //Aantal resterende tickets opslaan
            TicketType.SetAmount(typeID, aantal);
            
            string sql = "INSERT INTO Tickets (TicketEigenaar, TicketEmail, TicketTypeID, Aantal) VALUES (@Holder, @Email, @TypeID, @Amount)";

            DbParameter param1 = Database.AddParameter("@Holder", houder);
            DbParameter param2 = Database.AddParameter("@Email", email);
            DbParameter param3 = Database.AddParameter("@TypeID", typeID);
            DbParameter param4 = Database.AddParameter("@Amount", aantal);
            Database.ModifyData(sql, param1, param2, param3, param4);

            Console.WriteLine("Besteld ticket toegevoegd aan database");
        }

        //Tickets afdrukken naar WORD
        public static void Print(Ticket t)
        {
            foreach (Ticket ssc in GetTickets())
            {
                if (ssc.ID == t.ID)
                {
                    string filename = "../../../Afgedrukte Tickets/" + ssc.Ticketholder + "_" + ssc.TicketType + ".docx";
                    File.Copy("template.docx", filename, true);

                    WordprocessingDocument newdoc = WordprocessingDocument.Open(filename, true);
                    IDictionary<String, BookmarkStart> bookmarks = new Dictionary<String, BookmarkStart>();
                    foreach (BookmarkStart bms in newdoc.MainDocumentPart.RootElement.Descendants<BookmarkStart>())
                    {
                        bookmarks[bms.Name] = bms;
                    }
                    bookmarks["Name"].Parent.InsertAfter<Run>(new Run(new Text(ssc.Ticketholder)), bookmarks["Name"]);
                    bookmarks["Email"].Parent.InsertAfter<Run>(new Run(new Text(ssc.TicketholderEmail)),
                    bookmarks["Email"]);
                    bookmarks["TicketType"].Parent.InsertAfter<Run>(new Run(new Text(ssc.TicketType.Name)), bookmarks["TicketType"]);
                    bookmarks["Amount"].Parent.InsertAfter<Run>(new Run(new Text(ssc.Amount.ToString())),
                    bookmarks["Amount"]);
                    newdoc.Close();
                }
            }
        }
    }
}
