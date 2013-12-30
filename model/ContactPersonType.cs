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

<<<<<<< HEAD
=======
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

>>>>>>> 15e65dc314323d0db0412bee0a93116d803f249c
        //Leesbaar maken
        public override string ToString()
        {
            string result = "";
            result += Name;
            return result;
        }
    }
}
