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
    class ContactPerson
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
<<<<<<< HEAD
        //public ContactPersonType JobRole { get; set; }
=======
>>>>>>> 15e65dc314323d0db0412bee0a93116d803f249c
        public string JobRole { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Zipcode { get; set; }
<<<<<<< HEAD
        public int Number { get; set; }
=======
>>>>>>> 15e65dc314323d0db0412bee0a93116d803f249c
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }

        

        //Ophalen Contactpersonen
        public static ObservableCollection<ContactPerson> GetContacts()
        {
            //Database openen en gegevens ophalen
            ObservableCollection<ContactPerson> contacts = new ObservableCollection<ContactPerson>();
            DbDataReader reader = Database.GetData("SELECT * FROM Werknemers");

            //Rij per rij overlopen en nieuw persoon aanmaken.
            foreach (DbDataRecord record in reader)
            {
                ContactPerson contact = Create(record);
                contacts.Add(contact);
            }
<<<<<<< HEAD

            return contacts; 
        }

        private static ContactPerson Create(IDataRecord record)
        {
            //Een nieuw contactpersoon aanmaken met alle bijbehorende gegevens.
            return new ContactPerson()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Name = record["Voornaam"].ToString(),
                Surname = record["Naam"].ToString(),
                Street = record["Straat_Nr"].ToString(),
                City = record["Gemeente"].ToString(),
                Zipcode = Convert.ToInt32(record["Postcode"].ToString()),
                Cellphone = record["GSM"].ToString(),
                Phone = record["Telefoon"].ToString(),
                Email = record["Email"].ToString(),
                JobRole = ContactPersonType.GetContactType(Convert.ToInt32(record["JobID"])).ToString(),
                Company = record["Bedrijf"].ToString()
            };
=======
            return contacts; 
>>>>>>> 15e65dc314323d0db0412bee0a93116d803f249c
        }

        //Het aanmaken van de contactpersoon (alle gegevens invullen)
        private static ContactPerson Create(IDataRecord record)
        {
            //Een nieuw contactpersoon aanmaken met alle bijbehorende gegevens.
            return new ContactPerson()
            {
                ID = Convert.ToInt32(record["ID"].ToString()),
                Name = record["Voornaam"].ToString(),
                Surname = record["Naam"].ToString(),
                Street = record["Straat_Nr"].ToString(),
                City = record["Gemeente"].ToString(),
                Zipcode = Convert.ToInt32(record["Postcode"].ToString()),
                Cellphone = record["GSM"].ToString(),
                Phone = record["Telefoon"].ToString(),
                Email = record["Email"].ToString(),
                JobRole = ContactPersonType.GetContactType(Convert.ToInt32(record["JobID"])).ToString(),
                Company = record["Bedrijf"].ToString()
            };
        }

        //Het leesbaar maken voor de listbox
        public override string ToString()
        {
            string result = "";
            result += "Naam: " + Name + " - ";
            result += "Functie: " + JobRole;
            return result;
        }

        //Opslaan/Updaten van de gegevens
        public static void UpdateContactPersons(int id, string name)
        {
            DbTransaction trans = Database.BeginTransAction();

            string sql = "UPDATE Werknemers SET Naam=@Name WHERE ID=@ID";
            DbParameter par1 = Database.AddParameter("@Name", name);
            DbParameter par2 = Database.AddParameter("@ID", id);
            Database.ModifyData(trans, sql, par1, par2);

            trans.Commit();

            Database.ReleaseConnection(trans.Connection);
        }

        //Nieuwe contactpersoon toevoegen
        public static void Add(string name, string surname, string street, string city, int zipcode, string cellphone, string phone, string email, string jobrole, string company)
        {
            int jobroleid = ContactPersonType.GetContactTypeID(jobrole);

            string sql = "INSERT INTO Werknemers (Voornaam, Naam, Straat_Nr, Gemeente, Postcode, GSM, Telefoon, Email, JobID, Bedrijf) VALUES (@Name,@Surname,@Street,@City,@Zipcode,@Cellphone,@Phone,@Email,@Jobrole,@Company)";
            DbParameter param1 = Database.AddParameter("@Name", name);
            DbParameter param2 = Database.AddParameter("@Surname", surname);
            DbParameter param3 = Database.AddParameter("@Street", street);
            DbParameter param4 = Database.AddParameter("@City", city);
            DbParameter param5 = Database.AddParameter("@Zipcode", zipcode);
            DbParameter param6 = Database.AddParameter("@Cellphone", cellphone);
            DbParameter param7 = Database.AddParameter("@Phone", phone);
            DbParameter param8 = Database.AddParameter("@Email", email);
            DbParameter param9 = Database.AddParameter("@Jobrole", jobroleid);
            DbParameter param10 = Database.AddParameter("@Company", company);
            Database.ModifyData(sql, param1, param2, param3, param4, param5, param6, param7, param8, param9, param10);

            Console.WriteLine("Opgeslagen");
        }
    }
}
