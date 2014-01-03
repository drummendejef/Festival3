using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Festival.model;

namespace Festival.view
{
    /// <summary>
    /// Interaction logic for Ticketing.xaml
    /// </summary>
    public partial class Ticketing : UserControl
    {
        public Ticketing()
        {
            InitializeComponent();
        }

        //Textbox leegmaken op klik
        private void Clear_Textbox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Clear_Textbox;
        }

        //Nieuw ticket toevoegen 
        private void CommandBinding_BestelTicket(object sender, ExecutedRoutedEventArgs e)
        {
            string houder = NewName.Text + " " + NewFirstName.Text;
            Ticket.Add(houder, NewEmail.Text, SelectedType.Text, Convert.ToInt32(SelectedAantal.Text));

            
            
            
            //AvailableTickets
        }     
    }
}
