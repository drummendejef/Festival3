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
    class TicketType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int AvailableTickets { get; set; }
        public int MaxAmount { get; set; }

        //Tickettype's ophalen
        public static ObservableCollection<TicketType> GetTypes()
        {
            //Database openen en gegevens ophalen
            ObservableCollection<TicketType> types = new ObservableCollection<TicketType>();
            DbDataReader reader = Database.GetData("SELECT * FROM TicketType");

            foreach (DbDataRecord record in reader)
            {
                TicketType type = Create(record);
                types.Add(type);
            }
            return types;
        }

        //Tickettype aanmaken
        private static TicketType Create(IDataRecord record)
        {
            return new TicketType()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Name = record["Naam"].ToString(),
                Price = Convert.ToInt32(record["Prijs"].ToString()),
                AvailableTickets = Convert.ToInt32(record["Resterend"].ToString()),
                MaxAmount = Convert.ToInt32(record["MaxAantal"].ToString())
            };
        }

        //Tickettype toevoegen
        public static void Add(string name, double prijs, int beschikbaar)
        {
            int resterend = beschikbaar;

            string sql = "INSERT INTO TicketType (Naam, Prijs, MaxAantal, Resterend) VALUES (@Name, @Prijs, @Beschikbaar, @Resterend)";
            DbParameter param1 = Database.AddParameter("@Name", name);
            DbParameter param2 = Database.AddParameter("@Prijs", prijs);
            DbParameter param3 = Database.AddParameter("@Beschikbaar", beschikbaar);
            DbParameter param4 = Database.AddParameter("@Resterend", resterend);

            Database.ModifyData(sql, param1, param2, param3);

            Console.WriteLine("Nieuw tickettype toegevoegd");
        }

        //ID omzetten naar naam
        public static TicketType GetTicketType(int id)
        {
            foreach (TicketType type in GetTypes())
            {
                if (type.ID == id)
                {
                    return new TicketType()
                    {
                        Name = type.Name.ToString(),
                        Price = Convert.ToInt32(type.Price.ToString()),
                        AvailableTickets = Convert.ToInt32(type.AvailableTickets.ToString())
                    };
                } 
            }

            Console.WriteLine("Probleem bij omzetten tickettype ID naar Naam");
            return null;
        }

        //naam omzetten naar ID
        public static int GetTicketID(string naam)
        {
            foreach (TicketType type in GetTypes())
            {
                if (type.Name == naam) return type.ID;
            }

            Console.WriteLine("Probleem bij omzetten tickettype Naam naar ID");
            return 0;
        }

        //Leesbaar maken voor listboxes ect
        public override string ToString()
        {
            string result = "";
            result = Name;
            return result;
        }

        //Aantal overblijvende tickets aanpassen
        public static void SetAmount(int id, int gekochtaantal)
        {
            //*********************
            //AANTAL RESTERENDE TICKETS AANPASSEN TODO
            //********************

            //foreach (TicketType type in GetTypes())
            //{
            //    if (type.ID == id)
            //    {
            //        DbDataReader reader = Database.GetData("SELECT Resterend FROM TicketType WHERE ID=@id");
            //    }
            //}

            //string sql = "UPDATE TicketType SET Resterend=@resterend WHERE ID=@ID";
                    
                    
                    

        }
    }
}
