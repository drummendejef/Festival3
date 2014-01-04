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
    /// Interaction logic for ContactPersonen.xaml
    /// </summary>
    public partial class ContactPersonen : UserControl
    {
        public ContactPersonen()
        {
            InitializeComponent();
        }

        //Als er op de "opslaan" button geklikt wordt, komt men hier in.
        private void CommandBinding_ExecutedSave(object sender, ExecutedRoutedEventArgs e)
        {
            //Is het een bestaand contactpersoon die aangepast wordt?
            if (Contactpersonen.SelectedItems.Count > 0)//Ja
            {
                ContactPerson b =  (ContactPerson)Contactpersonen.SelectedItem;
                ContactPerson.UpdateContactPersons(b);
            }
            else //neen
            {
                ContactPerson.Add(name.Text, surname.Text, street.Text, city.Text, Convert.ToInt32(zipcode.Text), cellphone.Text, phone.Text, email.Text, jobrole.Text, company.Text);
            }
        }

        //Als er op de delete button geklikt wordt, komt men hier in.
        private void CommandBinding_DeleteContactPerson(object sender, ExecutedRoutedEventArgs e)
        {
            ContactPerson b = (ContactPerson)Contactpersonen.SelectedItem;
            ContactPerson.delete(b);
        }
    }
}
