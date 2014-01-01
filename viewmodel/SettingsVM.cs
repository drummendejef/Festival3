using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;

namespace Festival.viewmodel
{
    class SettingsVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "Settings"; }
        }

        public SettingsVM()
        {
            _festivalinfo = Festival.model.Festival.GetFestivals()[0];
        }

        private Festival.model.Festival _festivalinfo;
        public Festival.model.Festival FestivalInfo
        {
            get { return _festivalinfo; }
            set { _festivalinfo = value; OnPropertyChanged("FestivalInfo"); }
        }
        

    }
}
