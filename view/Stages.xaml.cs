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
using Microsoft.Win32;

namespace Festival.view
{
    /// <summary>
    /// Interaction logic for Stages.xaml
    /// </summary>
    public partial class Stages : UserControl
    {
        public Stages()
        {
            InitializeComponent();
        }

        //Podium aanpassen
        private void CommandBinding_PodiumBewerken(object sender, ExecutedRoutedEventArgs e)
        {
            //Is er een podium geselecteerd? Bewerken
            if(GeselecteerdPodium.Text.Count() > 0)
            {
                Stage.Update(Podiumnaam.Text, GeselecteerdPodium.Text);
            }

        }

        //Nieuw Podium aanmken
        private void CommandBinding_PodiumNieuw(object sender, ExecutedRoutedEventArgs e)
        {
            Stage.Add(Podiumnaam.Text);
        }

        //Afbeelding opslaan
        private void CommandBinding_OpenPicture(object sender, ExecutedRoutedEventArgs e)
        {
            //Verwijderd wegens errors.
        }
    }
}
