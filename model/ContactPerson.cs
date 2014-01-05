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
    class ContactPerson : INotifyPropertyChanged, IDataErrorInfo
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "De voornaam is verplicht")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De naam moet tussen de 3 en 50 karakters bevatten ")]
        public string Name { get; set; }
        [Required(ErrorMessage = "De naam is verplicht")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De voornaam moet tussen de 3 en 50 karakters bevatten ")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Het Bedrijf is verplicht")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De Bedrijfsnaam moet tussen de 3 en 50 karakters bevatten ")]
        public string Company { get; set; }
        [Required(ErrorMessage = "De job is verplicht")]
        public string JobRole { get; set; }
        [Required(ErrorMessage = "De stad is verplicht")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "De stad moet tussen de 2 en 50 karakters bevatten ")]
        public string City { get; set; }
        [Required(ErrorMessage = "De straat is verplicht")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "De straatnaam moet tussen de 3 en 50 karakters bevatten ")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Postcode is verplicht")]
        [StringLength(4, MinimumLength = 4, ErrorMessage = "Postcode moet 4 tekens bevatten")]
        public int Zipcode { get; set; }
        [Required(ErrorMessage = "Emailadres is verplicht")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefoonnummer is verplicht")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[/. ]?([0-9]{2})[.. ]?([0-9]{2})[..]?([0-9]{2})$", ErrorMessage = "Telefoonnummer niet correct.")]
        public string Phone { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[/. ]?([0-9]{2})[.. ]?([0-9]{2})[..]?([0-9]{2})$", ErrorMessage = "GSMnummer niet correct.")]
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

            //Database verbinding sluiten.
            if (reader != null)
                reader.Close();

            return contacts;
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
        public static void UpdateContactPersons(ContactPerson p)
        {
            int jobroleid = ContactPersonType.GetContactTypeID(p.JobRole);

            string sql = "UPDATE Werknemers SET Voornaam=@Name, Naam=@Surname, Straat_Nr=@Street, Gemeente=@City, Postcode=@Zipcode, GSM=@Cellphone, JobID=@Jobrole, Bedrijf=@Company, Telefoon=@Phone, Email= WHERE ID=@ID";


            DbParameter par1 = Database.AddParameter("@Name", p.Name);
            DbParameter par2 = Database.AddParameter("@ID", p.ID);
            DbParameter par3 = Database.AddParameter("@Surname", p.Surname);
            DbParameter par4 = Database.AddParameter("@Street", p.Street);
            DbParameter par5 = Database.AddParameter("@City", p.City);
            DbParameter par6 = Database.AddParameter("@Zipcode", p.Zipcode);
            DbParameter par7 = Database.AddParameter("@Cellphone", p.Cellphone);
            DbParameter par8 = Database.AddParameter("@Phone", p.Phone);
            DbParameter par9 = Database.AddParameter("@Email", p.Email);
            DbParameter par10 = Database.AddParameter("@Jobrole", jobroleid);
            DbParameter par11 = Database.AddParameter("@Company", p.Company);
            Database.ModifyData(sql, par1, par2, par3, par4, par5, par6, par7, par8, par9, par10, par11);

            Console.WriteLine("Persoon geupdate");
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

        //Contactpersoon verwijderen
        public static void delete(ContactPerson b)
        {
            int id = b.ID;

            //Probeer
            try
            {
                string sql = "DELETE FROM Werknemers WHERE ID=@ID";
                DbParameter param1 = Database.AddParameter("@ID", id);
                Database.ModifyData(sql, param1);

                Console.WriteLine("Contactpersoon verwijderd");
            }
            //mislukt
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
