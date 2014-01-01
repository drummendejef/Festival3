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

        
    }
}
