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

        private void CommandBinding_Save(object sender, ExecutedRoutedEventArgs e)
        {
            ContactPersonType.Add(AddJob.Text);
        }

        //Doorverwijzen naar Festival.cs om de naam op te slaan
        private void festivalnaam_opslaan(object sender, RoutedEventArgs e)
        {
            Festival.model.Festival.SaveN(FestivalNaam.Text);
        }

        //Doorverwijzen naar Festival.cs om de beschrijving op te slaan
        private void festivalbeschrijving_opslaan(object sender, RoutedEventArgs e)
        {
            Festival.model.Festival.SaveD(FestivalBeschrijving.Text);
        }

        private void festivaleinddatum_opslaan(object sender, RoutedEventArgs e)
        {
            Festival.model.Festival.SaveE(Convert.ToDateTime(Einddatum.Text));
        }

        
    }
}
