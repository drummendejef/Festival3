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
    class LineUp
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime From { get; set; }
        //public string From { get; set; }
        public DateTime Until { get; set; }
        //public string Until { get; set; }
        public Stage Stage { get; set; }
        public Band Band { get; set; }

        //Ophalen Lineup
        public static ObservableCollection<LineUp> GetLineUp()
        {
            //Database openen en gegevens ophalen
            ObservableCollection<LineUp> lineups = new ObservableCollection<LineUp>();
            try
            {
                DbDataReader reader = Database.GetData("SELECT * FROM LineUp");

                //Rij per rij overlopen en nieuwe linup maken.
                foreach (DbDataRecord record in reader)
                {
                    LineUp lineup = Create(record);
                    lineups.Add(lineup);
                }

                //Database verbinding sluiten.
                if (reader != null)
                    reader.Close();

                return lineups;
            }
            //fail
            catch(Exception ex)
            {
                Console.WriteLine("Linup ophalen gefaald:\n" + ex.Message);
                return null;
            }
        }

        private static LineUp Create(IDataRecord record)
        {
            //Een nieuwe linup aanmaken met alle bijbehorende gegevens.
            return new LineUp()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Date = (DateTime)record["Datum"],
                From = (DateTime)record["Starttijd"],
                Until = (DateTime)record["Eindtijd"],
                Stage = Stage.GetStage(Convert.ToInt32(record["PodiumID"].ToString())),
                Band = Band.GetBand(Convert.ToInt32(record["BandID"].ToString()))
            };
        }
    }
}
