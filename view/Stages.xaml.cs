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
    /// Interaction logic for Stages.xaml
    /// </summary>
    public partial class Stages : UserControl
    {
        public Stages()
        {
            InitializeComponent();
        }

        //Nieuw podium opslaan, podium aanpassen
        private void CommandBinding_PodiumOpslaan_Bewerken(object sender, ExecutedRoutedEventArgs e)
        {
            //Is er een podium geselecteerd? Dan is het bewerken.
            if(GeselecteerdPodium.Text.Count() > 0)
            {
                Stage.Update(Podiumnaam.Text, GeselecteerdPodium.Text);
            }

        }
    }
}
