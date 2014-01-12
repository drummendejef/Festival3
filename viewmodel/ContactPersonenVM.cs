using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Festival.model;
using Festival.view;
using GalaSoft.MvvmLight.Command;

namespace Festival.viewmodel
{
    class ContactPersonenVM : ObservableObject, IPage
    {
        public ContactPersonenVM()
        {
            ContactsList = ContactPerson.GetContacts();
            Joblist = ContactPersonType.GetContactTypes();
            SearchName = "Zoek naam";
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

        //Persoon op naam zoeken
        private string _searchname;
        public string SearchName
        {
            get { return _searchname; }
            set { _searchname = value; OnPropertyChanged("SearchName"); }
        }



        public ICommand SearchContactCommand
        {
            get 
            { 
                //Zoekt hij op naam of job?
                //
                if (SearchJob == "")
                    return new RelayCommand<ContactPersonenVM>(SearchContact);
                else
                    return new RelayCommand<ContactPersonenVM>(SearchContactJob);

            }
        }

        //Zoek contactpersonen op naam
        private void SearchContact(ContactPersonenVM contactvm)
        {
            ContactsList = ContactPerson.SearchContactPerson(SearchName);
        }

        //Persoon op beroep zoeken
        private string _searchjob;
        public string SearchJob
        {
            get { return _searchjob; }
            set { _searchjob = value; OnPropertyChanged("SearchJob"); }
        }

        //Zoek contactpersonen op job
        private void SearchContactJob(ContactPersonenVM contactvm)
        {
            //ContactList = ContactPerson.SearchContactJob(SearchJob);
        }


        
        
    }
}
