using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;
using System.Windows.Controls;

namespace Festival.viewmodel
{
    class StartPageVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "StartPageVM"; }
        }

        public StartPageVM()
        {
            //_FestivalList = Festival.model.Festival.GetFestivals();
        }

        private ObservableCollection<Festival.model.Festival> _FestivalList;
        public ObservableCollection<Festival.model.Festival> FestivalList
        {
            get { return _FestivalList; }
            set { _FestivalList = value; OnPropertyChanged("FestivalList"); }
        }

        private Festival.model.Festival _selectedFestival;
        public Festival.model.Festival SelectedFestival
        {
            get { return _selectedFestival; }
            set { _selectedFestival = value; OnPropertyChanged("SelectedFestival"); }
        }
    }
}
