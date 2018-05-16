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
using System.Data;
using System.Data.SqlClient;
using SaraD2.Class;

namespace SaraD2
{
    /// <summary>
    /// Interaction logic for Locations.xaml
    /// </summary>
    public partial class Locations : Window
    {
        SqlCommandBuilder cmdbl;
        SqlDataAdapter da;
        DataSet ds;
        public Locations()
        {
            InitializeComponent();
            get_Locs();
        }
        private void get_Locs()
        {
            ds = new DataSet();
            var cn = new SqlConnection(Connections.csFAC);
            string sQuery = "Select * from Locations";
            da = new SqlDataAdapter(sQuery, cn);
            da.Fill(ds, "Locations");
            int rCount = ds.Tables[0].Rows.Count;
            dgLoc.SetBinding(TextBox.TextProperty, "Locations");
            dgLoc.DataContext = ds.Tables[0].DefaultView;
        }

        private void btUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmdbl = new SqlCommandBuilder(da);
                da.Update(ds, "Locations");
                MessageBox.Show("Database updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            get_Locs();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var Fac = new Facilities();
            Fac.Show();
        }
    }
}
