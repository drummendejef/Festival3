using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;

namespace Festival.viewmodel
{
    class ContactPersonenVM : ObservableObject, IPage
    {
        public ContactPersonenVM()
        {
            ContactsList = ContactPerson.GetContacts();
            Joblist = ContactPersonType.GetContactTypes();
        }

        public string Name
        {
            get { return "Contactpersonen"; }
        }

        //Contactpersonenlijst
        private ObservableCollection<ContactPerson> _contactslist;
        public ObservableCollection<ContactPerson> ContactsList
        {
            get { return _contactslist; }
            set { _contactslist = value; OnPropertyChanged("ContactsList"); }
        }

        //Geselecteerde contact uit de lijst
        private ContactPerson _selectedcontact;
        public ContactPerson SelectedContact
        {
            get { return _selectedcontact; }
            set { _selectedcontact = value; OnPropertyChanged("SelectedContact"); }
        }
        
        //Joblijst
        private ObservableCollection<ContactPersonType> _joblist;
        public ObservableCollection<ContactPersonType> Joblist
        {
            get { return _joblist; }
            set { _joblist = value; OnPropertyChanged("Joblist"); }
        }
        
        //Geselecteerd type uit de lijst
        private ContactPersonType _selectedjob;
        public ContactPersonType SelectedJob
        {
            get { return _selectedjob; }
            set { _selectedjob = value; OnPropertyChanged("SelectedJob"); }
        }
    }
}
