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
    /// Interaction logic for Departments.xaml
    /// </summary>
    public partial class Departments : Window
    {
        SqlCommandBuilder cmdbl;
        SqlDataAdapter da;
        DataSet ds;
        public Departments()
        {
            InitializeComponent();
            getDepartments();
        }
       private void getDepartments ()
        {
          
            ds = new DataSet();
            var cn = new SqlConnection(Connections.csSQL);
            string sQuery = "Select * from Departments";
            da = new SqlDataAdapter(sQuery,cn);
            da.Fill(ds, "Departments");
            int rCount = ds.Tables[0].Rows.Count;
            dgDep.SetBinding(TextBox.TextProperty, "Deparments");
            dgDep.DataContext = ds.Tables[0].DefaultView;

        }

        private void btUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmdbl = new SqlCommandBuilder(da);
                da.Update(ds, "Departments");
                MessageBox.Show("Database updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            getDepartments();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var IT = new InfoTech();
            IT.Show();
        }
    }
}
