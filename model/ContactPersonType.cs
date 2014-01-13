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
    class ContactPersonType
    {
        public ContactPersonType() { }
        public ContactPersonType(ContactPersonType t)
        {
            _id = t._id;
            _name = t._name;
        }


        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        



        //Contacttypes ophalen
        public static ObservableCollection<ContactPersonType> GetContactTypes()
        {
            //Database openen en gegevens ophalen
            ObservableCollection<ContactPersonType> jobs = new ObservableCollection<ContactPersonType>();
            DbDataReader reader = Database.GetData("SELECT * FROM Jobs");

            foreach (DbDataRecord record in reader)
            {
                ContactPersonType job = Create(record);
                jobs.Add(job);
            }
            return jobs;
        }

        //Aanmaken nieuwe job
        private static ContactPersonType Create(IDataRecord record)
        {
            return new ContactPersonType()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Name = record["Job"].ToString()
            };
        }

        //Omzetten ID naar contacttype naam
        public static string GetContactType(int id)
        {
            foreach (ContactPersonType job in GetContactTypes())
            {
                if (job.ID == id) return job._name.ToString();
            }

            Console.WriteLine("Probleem bij omzetten van ID naar naam in contacttype.");
            return null;
        }

        //Omzetten contacttype naam naar ID
        public static int GetContactTypeID(string jobrole)
        {
            foreach (ContactPersonType job in GetContactTypes())
            {
                if (job.Name == jobrole) return job.ID;
            }

            Console.WriteLine("Probleem bij omzetten van naam naar ID in contacttype.");
            return 0;
        }

        //Leesbaar maken
        public override string ToString()
        {
            string result = "";
            result += Name;
            return result;
        }

        //Nieuwe job in Database aanmaken
        public static void Add(string jobnaam)
        {
            string sql = "INSERT INTO Jobs (Job) VALUES (@Jobnaam)";
            DbParameter param1 = Database.AddParameter("@Jobnaam", jobnaam);

            Database.ModifyData(sql, param1);

            Console.WriteLine("Nieuw jobtype opgeslagen");
        }

        //Bestaande job bewerken.
        public static void Update(ContactPersonType t)
        {
            string sql = "UPDATE Jobs SET Job=@Job WHERE ID=@Id";

            DbParameter par1 = Database.AddParameter("@Job", t.Name);
            DbParameter par2 = Database.AddParameter("@Id", t.ID);
            Database.ModifyData(sql, par1, par2);

            Console.WriteLine("Jobnaam aangepast");
        }
    }
}
