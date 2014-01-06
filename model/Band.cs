using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Festival.model
{
    class Band : INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public ObservableCollection<Genre> Genres { get; set; }

        //Ophalen Bands
        public static ObservableCollection<Band> GetBands()
        {
            //Database openen en gegevens ophalen
            ObservableCollection<Band> bands = new ObservableCollection<Band>();
            DbDataReader reader = Database.GetData("SELECT * FROM Bands");

            //Rij per rij overlopen en nieuwe band aanmaken.
            foreach (DbDataRecord record in reader)
            {
                Band band = Create(record);
                bands.Add(band);
            }
            return bands;
        }

        //Aanmaken van band
        public static Band Create(IDataRecord record)
        {
            string genres;
            genres = record["Genres"].ToString();
            string[] genreIDs = genres.Split('|');

            ObservableCollection<Genre> genresList = Genre.GetGenres();
            foreach (string id in genreIDs)
            {
                foreach (Genre g in genresList)
                {
                    if (g.ID == Convert.ToInt32(id))
                    {
                        g.isChecked = true;
                        break;
                    }
                }
            }

            return new Band()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Name = record["Naam"].ToString(),
                Picture = record["Foto"].ToString(),
                Twitter = record["Twitter"].ToString(),
                Facebook = record["Facebook"].ToString(),
                Genres = genresList
            };
        }

        //Leesbaar maken van band
        public override string ToString()
        {
            string result = "";
            result += Name;
            return result;
        }

        //Omzetten ID van Band naar Band band
        public static Band GetBand(int id)
        {
            foreach (Band band in GetBands())
            {
                if (band.ID == id) return band;
            }

            Console.WriteLine("Probleem bij omzetten van ID naar stage in stages.");
            return null;
        }


        // PROPERTY CHANGED EVENTHANDLER
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
