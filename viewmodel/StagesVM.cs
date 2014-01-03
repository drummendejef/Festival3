using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;
using Festival.view;

namespace Festival.viewmodel
{
    class StagesVM : ObservableObject, IPage
    {
        public StagesVM()
        {
            PodiaList = Stage.GetStages();
            GenreList = Genre.GetGenres();
            BandList = Band.GetBands();
        }
        
        public string Name
        {
            get { return "Stages"; }
        }

        //Lijst met alle podia
        private ObservableCollection<Stage> _podialist;
        public ObservableCollection<Stage> PodiaList
        {
            get { return _podialist; }
            set { _podialist = value; OnPropertyChanged("PodiaList"); }
        }

        //Lijst met alle bands
        private ObservableCollection<Band> _bandlist;
        public ObservableCollection<Band> BandList
        {
            get { return _bandlist; }
            set { _bandlist = value; OnPropertyChanged("BandList"); }
        }

        //Geselecteerde band
        private Band _selectedband;
        public Band SelectedBand
        {
            get { return _selectedband; }
            set { _selectedband = value; OnPropertyChanged("SelectedBand"); }
        }
        

        //Lijst met alle genres
        private ObservableCollection<Genre> _genrelist;
        public ObservableCollection<Genre> GenreList
        {
            get { return _genrelist; }
            set { _genrelist = value; OnPropertyChanged("GenreList"); }
        }


        
        
        
    }
}
