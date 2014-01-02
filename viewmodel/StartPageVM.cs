using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;
using System.Windows.Controls;
using System.ComponentModel;

namespace Festival.viewmodel
{
    class StartPageVM : ObservableObject, IPage, INotifyPropertyChanged
    {
        public StartPageVM()
        {
            //Info van het festival via de klasse Festival gaan ophalen in de database
            FestivalInfo = Festival.model.Festival.GetFestivals()[0];
        }
        
        public string Name
        {
            get { return "StartPage"; }
        }

        //De Databinding van de festivalinfo
        private Festival.model.Festival _festivalinfo;
        public Festival.model.Festival FestivalInfo
        {
            get { return _festivalinfo; }
            set { _festivalinfo = value; OnPropertyChanged("FestivalInfo"); }
        }   
    }
}
