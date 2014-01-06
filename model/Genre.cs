using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Festival.model
{
    class Genre : IDataErrorInfo, INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "De Genrenaam is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "The length must be between 2 and 50 characters")]
        public bool isChecked { get; set; }

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


        //IDataErrorinfo interface geimplementeerd.
        public string Error
        {
            get { return null; }
        }

        public string this[string columnName]
        {
            get
            {
                try
                {
                    object value = this.GetType().GetProperty(columnName).GetValue(this);
                    Validator.ValidateProperty(value, new ValidationContext(this, null, null) { MemberName = columnName });
                }
                catch (ValidationException ex)
                {
                    return ex.Message;
                }
                return String.Empty;
            }
        }
        //Einde data validatie


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
