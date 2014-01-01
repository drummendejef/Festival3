using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Festival.model
{
    class Festival
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Beschrijving { get; set; }

        public static ObservableCollection<Festival> GetFestivals()
        {
            ObservableCollection<Festival> festivals = new ObservableCollection<Festival>();
            DbDataReader reader = Database.GetData("SELECT * FROM Festival");

            //Rij overlopen en festival informatie ophalen
            foreach (DbDataRecord record in reader)
            {
                Festival festival = Create(record);
                festivals.Add(festival);
            }
            return festivals;
            
        }

        //Festivalgegevens aanmaken
        private static Festival Create(IDataRecord record)
        {
            return new Festival()
            {
                Name = record["Festivalnaam"].ToString(),
                Beschrijving = record["Omschrijving"].ToString(),
                StartDate = Convert.ToDateTime(record["Startdatum"]),
                EndDate = Convert.ToDateTime(record["Einddatum"].ToString())
            };
        }

        //Festivalnaam opslaan.
        public static void SaveN(string Festivalnaam)
        {
            string sql = "UPDATE Festival SET FestivalNaam=@Festivalnaam WHERE ID=1";

            DbParameter par1 = Database.AddParameter("@Festivalnaam", Festivalnaam);
            Database.ModifyData(sql, par1);
        }

        //Festivalbeschrijving opslaan
        public static void SaveD(string Festivalbeschrijving)
        {
            string sql = "UPDATE Festival SET Omschrijving=@Festivalbeschrijving WHERE ID=1";

            DbParameter par1 = Database.AddParameter("@Festivalbeschrijving", Festivalbeschrijving);
            Database.ModifyData(sql, par1);
        }

        //Festival Startdatum opslaan
        public static void SaveS(DateTime datum)
        {
            string sql = "UPDATE Festival SET Startdatum=@startdatum WHERE ID=1";

            DbParameter par1 = Database.AddParameter("@startdatum", datum);
            Database.ModifyData(sql, par1);
        }

        //Festival Einddatum opslaan
        public static void SaveE(DateTime datum)
        {
            string sql = "UPDATE Festival SET Einddatum=@einddatum WHERE ID=1";

            DbParameter par1 = Database.AddParameter("@einddatum", datum);
            Database.ModifyData(sql, par1);
        }
        
    }
}
