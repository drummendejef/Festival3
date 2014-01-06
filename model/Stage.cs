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

namespace Festival.model
{
    class Stage : INotifyPropertyChanged, IDataErrorInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Ophalen podia
        public static ObservableCollection<Stage> GetStages()
        {
            //Database openen en gegevens ophalen
            ObservableCollection<Stage> stages = new ObservableCollection<Stage>();
            DbDataReader reader = Database.GetData("SELECT * FROM Podia");

            //Rij per rij overlopen en nieuw podium aanmaken.
            foreach (DbDataRecord record in reader)
            {
                Stage stage = Create(record);
                stages.Add(stage);
            }
            return stages;
        }

        //Aanmaken van Podium
        public static Stage Create(IDataRecord record)
        {
            return new Stage()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Name = record["Naam"].ToString()
            };
        }

        //Opslaan Podia
        public static void Add(string name)
        {
            string sql = "INSERT INTO Podia (Naam) VALUES (@Name)";
            DbParameter param1 = Database.AddParameter("@Name", name);
            Database.ModifyData(sql, param1);

            Console.WriteLine("Podium toegevoegd");
        }

        //Leesbaar maken voor jan en alleman
        public override string ToString()
        {
            string result = "";
            result += Name;
            return result;
        }

        //Updaten van naam
        public static void Update(string nieuwenaam, string oudenaam)
        {
            foreach (Stage stage in GetStages())
            {
                if (stage.Name == oudenaam)
                {
                    string sql = "UPDATE Podia SET Naam=@Nieuw WHERE Naam=@Oud";
                    DbParameter param1 = Database.AddParameter("@Nieuw", nieuwenaam);
                    DbParameter param2 = Database.AddParameter("@Oud", oudenaam);
                    Database.ModifyData(sql, param1, param2);

                    stage.Name = nieuwenaam;

                    Console.WriteLine("Podiumnaam geupdate");
                }
            }
        }

        //Omzetten ID naar Stage stage
        public static Stage GetStage(int id)
        {
            foreach (Stage stage in GetStages())
            {
                if (stage.ID == id) return stage;
            }

            Console.WriteLine("Probleem bij omzetten van ID naar stage in stages.");
            return null;
        }

        /* ----------------------------------------------------------------- */
        // PROPERTY CHANGED EVENTHANDLER
        /* ----------------------------------------------------------------- */
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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
        //Einde data validation
        
    }
}
