using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;


namespace Festival.viewmodel
{
    class LineUpVM : ObservableObject, IPage
    {
        public string Name
        {
            get { return "LineUp"; }
        }

        public LineUpVM()
        {
            Bands = Band.GetBands();
            Stages = Stage.GetStages();
            LineUps = LineUp.GetLineUp();

            SelectedSlot = new LineUp();

            Hours = new ObservableCollection<int>();
            for (int i = 0; i < 24; ++i)
                Hours.Add(i);

            Minutes = new ObservableCollection<int>();
            for (int i = 0; i < 60; i += 5)
                Minutes.Add(i);

            //CancelUpdateSlot(this);

            SelectedSlot = new LineUp();
            StartDate = DateTime.Now;

            _oldSlot = null;

            //Enabled = true;
            //ShowEdit = "Hidden";
            //ShowCancel = "Hidden";
            //ShowSave = "Visible";
        }

        private ObservableCollection<Band> _bands;
        public ObservableCollection<Band> Bands
        {
            get { return _bands; }
            set { _bands = value; OnPropertyChanged("Bands"); }
        }

        private ObservableCollection<Stage> _stages;
        public ObservableCollection<Stage> Stages
        {
            get { return _stages; }
            set { _stages = value; OnPropertyChanged("Stages"); }
        }

        private ObservableCollection<LineUp> _lineups;
        public ObservableCollection<LineUp> LineUps
        {
            get { return _lineups; }
            set { _lineups = value; OnPropertyChanged("LineUps"); }
        }

        private LineUp _oldSlot;
        private LineUp _selectedSlot;
        public LineUp SelectedSlot
        {
            get { return _selectedSlot; }
            set
            {
                _selectedSlot = value;

                // Reset Date
                if (SelectedSlot == null)
                {
                    StartDate = DateTime.Now;
                    EndDate = DateTime.Now;
                }
                else
                {
                    StartDate = SelectedSlot.From;
                    EndDate = SelectedSlot.Until;
                    Duration = EndDate - StartDate;
                }

                OnPropertyChanged("SelectedSlot");
                //if (!_changeNotify)
                //{
                //    _changeNotify = !_changeNotify;
                //    return;
                //}
                //SelectionChanged(this);
            }
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }

        public ObservableCollection<int> Hours { get; set; }
        public ObservableCollection<int> Minutes { get; set; }


        
        
        


        
    }
}
