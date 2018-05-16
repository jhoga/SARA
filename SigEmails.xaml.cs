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
using SaraD2.Class;
using System.Data;
using System.Data.SqlClient;

namespace SaraD2
{
    /// <summary>
    /// Interaction logic for SigEmails.xaml
    /// </summary>
    public partial class SigEmails : Window
    {
        SqlCommandBuilder cmd1;
        DataSet ds;
        SqlDataAdapter da;
        public SigEmails()
        {
            InitializeComponent();
            getEmailData();
        }
        private void getEmailData()
        {
            ds = new DataSet();
            var cn = new SqlConnection(Connections.csSig);
            string sQuery = "Select * from TechResTable";
            da = new SqlDataAdapter(sQuery, cn);
            da.Fill(ds, "TechResTable");
            int rCount = ds.Tables[0].Rows.Count;
            EmailDG.SetBinding(TextBox.TextProperty, "TechResTable");
            EmailDG.DataContext = ds.Tables[0].DefaultView;
        }

        private void upEmail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmd1 = new SqlCommandBuilder(da);
                da.Update(ds, "TechResTable");
                MessageBox.Show("Database updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                getEmailData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
    

}
