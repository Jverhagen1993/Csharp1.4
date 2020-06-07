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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public MainWindow()
        {
            InitializeComponent();
            dgDranken.ItemsSource = db.Drankens.ToList();
        }

        private void dgDranken_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var drank = (Dranken)dgDranken.SelectedItem;
            txtNaam.Text = drank.NAAM;
            txtSoort.Text = drank.SOORT;
            txtPrijs.Text = drank.PRIJS;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var drank = new Dranken();
            drank.NAAM = txtNaam.Text;
            drank.SOORT = txtSoort.Text;
            drank.PRIJS = txtPrijs.Text;
            db.Drankens.InsertOnSubmit(drank);
            db.SubmitChanges();

            dgDranken.ItemsSource = db.Drankens.ToList();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            dgMain.Children.Clear();
            dgMain.Children.Add(new UserControl1());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtNaam.Text != null)
            {
                var DrUpdate = (Dranken)dgDranken.SelectedItem;
                DrUpdate.NAAM = txtNaam.Text;
                DrUpdate.SOORT = txtSoort.Text;
                DrUpdate.PRIJS = txtPrijs.Text;
                db.SubmitChanges();

                dgDranken.ItemsSource = db.Drankens.ToList();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            {
                DataClasses1DataContext dr = new DataClasses1DataContext();
                Dranken DrDelete = dgDranken.SelectedItem as Dranken;
                var drankie = (from Dranken in dr.Drankens
                               where Dranken.ID == DrDelete.ID
                               select Dranken).Single();
                dr.Drankens.DeleteOnSubmit(drankie);
                dr.SubmitChanges();
                dgDranken.ItemsSource = db.Drankens.ToList();

            }
        }
    }
}
