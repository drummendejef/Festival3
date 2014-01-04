using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Festival.model;

namespace Festival.viewmodel
{
    class TicketsVM : ObservableObject, IPage
    {
        public TicketsVM()
        {
            TicketList = Ticket.GetTickets();
            TicketTypeList = TicketType.GetTypes();
        }

        public string Name
        {
            get { return "Tickets"; }
        }

        //Lijst met alle tickets
        private ObservableCollection<Ticket> _ticketlist;
        public ObservableCollection<Ticket> TicketList
        {
            get { return _ticketlist; }
            set { _ticketlist = value; OnPropertyChanged("TicketList"); }
        }

        //Geselecteerd ticket uit de lijst.
        private Ticket _selectedticket;
        public Ticket SelectedTicket
        {
            get { return _selectedticket; }
            set { _selectedticket = value; OnPropertyChanged("SelectedTicket"); }
        }

        private ObservableCollection<TicketType> _tickettypelist;
        public ObservableCollection<TicketType> TicketTypeList
        {
            get { return _tickettypelist; }
            set { _tickettypelist = value; OnPropertyChanged("SelectedTicket");}
        }
        

        //Geselecteerd tickettype
        private TicketType _selectedtickettype;
        public TicketType SelectedTicketType
        {
            get { return _selectedtickettype; }
            set { _selectedtickettype = value; OnPropertyChanged("SelectedTicketType");}
        }

        //Geselecteerd bestel ticket
        private TicketType _selectedordertype;
        public TicketType SelectedOrderType
        {
            get { return _selectedordertype; }
            set { _selectedordertype = value; OnPropertyChanged("SelectedOrderType"); }
        }     


        
        
    }
}
