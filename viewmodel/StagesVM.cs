using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;
using Festival.view;

namespace Festival.viewmodel
{
    class StagesVM : ObservableObject, IPage, INotifyPropertyChanged
    {
        public StagesVM()
        {
            PodiaList = Stage.GetStages();
            GenreList = Genre.GetGenres();
            BandList = Band.GetBands();
            GenreSelectedList = Genre.GetGenres();
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

        //Geselecteerd podium
        private Stage _selectedpodium;
        public Stage SelectedPodium
        {
            get { return _selectedpodium; }
            set { _selectedpodium = value; OnPropertyChanged("SelectedPodium"); }
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
            set 
            { 
                _selectedband = value;
                GenreSelectedList = (value == null) ? Genre.GetGenres() : value.Genres;
                OnPropertyChanged("SelectedBand"); }
        }
        

        //Lijst met alle genres
        private ObservableCollection<Genre> _genrelist;
        public ObservableCollection<Genre> GenreList
        {
            get { return _genrelist; }
            set { _genrelist = value; OnPropertyChanged("GenreList"); }
        }

        //Genres van geselecteerde band
        private ObservableCollection<Genre> _genreselectedlist;
        public ObservableCollection<Genre> GenreSelectedList
        {
            get { return _genreselectedlist; }
            set { _genreselectedlist = value; }
        }
      
    }
}
