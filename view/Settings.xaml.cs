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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Festival.model;

namespace Festival.view
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
        }

        //Nieuwe job toevoegen
        private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e)
        {
            //Zit er wel iets in het vakje?
            if (AddJob.Text.Count() > 0)
                ContactPersonType.Add(AddJob.Text);
            else
                Console.WriteLine("Het job vakje was leeg");
        }

        //Doorverwijzen naar Festival.cs om de naam op te slaan
        private void festivalnaam_opslaan(object sender, RoutedEventArgs e)
        {
            //Zit er wel iets in?
            if (FestivalNaam.Text.Count() > 0)
                Festival.model.Festival.SaveN(FestivalNaam.Text);
            else
                Console.WriteLine("Geen Festivalnaam ingegeven");
        }

        //Doorverwijzen naar Festival.cs om de beschrijving op te slaan
        private void festivalbeschrijving_opslaan(object sender, RoutedEventArgs e)
        {
            Festival.model.Festival.SaveD(FestivalBeschrijving.Text);
        }
        //einddatum opslaan
        private void festivaleinddatum_opslaan(object sender, RoutedEventArgs e)
        {
            Festival.model.Festival.SaveE(Convert.ToDateTime(Einddatum.Text));
        }
        //startdatum opslaan
        private void festivalstartdatum_opslaan(object sender, RoutedEventArgs e)
        {
            Festival.model.Festival.SaveS(Convert.ToDateTime(Startdatum.Text));
        }

        //Nieuw genre opslaan
        private void CommandBinding_GenreSave(object sender, ExecutedRoutedEventArgs e)
        {
            //Zit er wel iets in het vakje?
            if (AddGenre.Text.Count() > 0)
                Genre.Add(AddGenre.Text);
            else
                Console.WriteLine("Geen Genre ingegeven");
        }

        
    }
}
