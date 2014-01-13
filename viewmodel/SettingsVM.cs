using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;

namespace Festival.viewmodel
{
    class SettingsVM : ObservableObject, IPage, INotifyPropertyChanged
    {
        public string Name
        {
            get { return "Settings"; }
        }

        public SettingsVM()
        {
            _festivalinfo = Festival.model.Festival.GetFestivals()[0];
            JobList = ContactPersonType.GetContactTypes();
        }

        //Alle algemene festivalinfo
        private Festival.model.Festival _festivalinfo;
        public Festival.model.Festival FestivalInfo
        {
            get { return _festivalinfo; }
            set { _festivalinfo = value; OnPropertyChanged("FestivalInfo"); }
        }

        //Lijst met jobs
        private  ObservableCollection<ContactPersonType> _joblist;
        public ObservableCollection<ContactPersonType> JobList
        {
            get { return _joblist; }
            set { _joblist = value; OnPropertyChanged("JobList"); }
        }

        //Geselecteerde job in joblijst
        private ContactPersonType _selectedjob;
        public ContactPersonType SelectedJob
        {
            get { return _selectedjob; }
            set { _selectedjob = value; OnPropertyChanged("SelectedJob"); }
        }
        

    }
}
