using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Festival.model
{
    class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Genres ophalen
        public static ObservableCollection<Genre> GetGenres()
        {
            ObservableCollection<Genre> genres = new ObservableCollection<Genre>();
            DbDataReader reader = Database.GetData("SELECT * FROM Genre");

            //Rij overlopen en genres ophalen
            foreach (DbDataRecord record in reader)
            {
                Genre genre = Create(record);
                genres.Add(genre);
            }
            return genres;
        }

        //Genre aanmaken
        private static Genre Create(IDataRecord record)
        {
            return new Genre()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Name = record["Naam"].ToString()
            };
        }

        //Nieuw genre opslaan
        public static void Add(string genrenaam)
        {
            string sql = "INSERT INTO Genre (Naam) VALUES (@Genrenaam)";
            DbParameter param1 = Database.AddParameter("@Genrenaam", genrenaam);

            Database.ModifyData(sql, param1);

            Console.WriteLine("Nieuw Genre opgeslagen");
        }
    }
}
