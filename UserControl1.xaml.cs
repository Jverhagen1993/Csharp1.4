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

namespace Drankregistratie
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public UserControl1()
        {
            InitializeComponent();
        }

        private void btnID_Click(object sender, RoutedEventArgs e)
        {
            string ID = txtID.Text;
            var show = db.Drankens.Where(p => Convert.ToString(p.ID).Contains(ID));
            dgDrank.ItemsSource = show;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (txtNaam.Text != null)
            {
                var DrUpdate = (Dranken)dgDrank.SelectedItem;
                DrUpdate.NAAM = txtNaam.Text;
                DrUpdate.SOORT = txtSoort.Text;
                DrUpdate.PRIJS = txtPrijs.Text;
                db.SubmitChanges();

                string ID = txtID.Text;
                var show = db.Drankens.Where(p => Convert.ToString(p.ID).Contains(ID));
                dgDrank.ItemsSource = show;
            }
        }

        private void dgDrank_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var drank = (Dranken)dgDrank.SelectedItem;
            txtNaam.Text = drank.NAAM;
            txtSoort.Text = drank.SOORT;
            txtPrijs.Text = drank.PRIJS;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
     
            {
                DataClasses1DataContext dr = new DataClasses1DataContext();
                Dranken DrDelete = dgDrank.SelectedItem as Dranken;
                var drankie = (from Dranken in dr.Drankens
                        where Dranken.ID == DrDelete.ID
                        select Dranken).Single();
                dr.Drankens.DeleteOnSubmit(drankie);
                dr.SubmitChanges();
                dgDrank.ItemsSource = db.Drankens.ToList();

                string ID = txtID.Text;
                var show = db.Drankens.Where(p => Convert.ToString(p.ID).Contains(ID));
                dgDrank.ItemsSource = show;
            }
        }
    }
}
