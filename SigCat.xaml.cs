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
    /// Interaction logic for SigCat.xaml
    /// </summary>
    public partial class SigCat : Window
    {
        DataSet ds;
        DataSet ds2;

        SqlDataAdapter da;
        SqlDataAdapter da2;
        SqlCommandBuilder cmd1;
        SqlCommandBuilder cmd2;
        string subCatTable;
        public SigCat()
        {
            InitializeComponent();
            getCats();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmd1 = new SqlCommandBuilder(da);
                da.Update(ds, "SigCatMain");
                MessageBox.Show("Database updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                System.Data.DataRowView drv = (System.Data.DataRowView)this.dgCat.SelectedItem;
                string s1 = (drv[2].ToString()).Trim();
                subCatTable = s1;
                try
                {
                    getSubCats(s1);
                }
                catch
                {
                    MessageBox.Show("Could not find the Sub-Category table");
                }
            }
            catch { }

        }

        private void btSub_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataRowView drv = (System.Data.DataRowView)this.dgSubCat.SelectedItem;
            string s1 = subCatTable;
            try
            {
                updateSub(s1);
            }
            catch
            {
                MessageBox.Show("Could not find the Sub-Category table");
            }
        }
        private void updateSub(string tableName)
        {
            try
            {
                cmd2 = new SqlCommandBuilder(da2);
                da2.Update(ds2, tableName);
                MessageBox.Show("Database updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void getCats()
        {

            ds = new DataSet();
            var cn = new SqlConnection(Connections.csSig);
            string sQuery = "Select * from SigCatMain";
            da = new SqlDataAdapter(sQuery, cn);
            da.Fill(ds, "SigCatMain");
            int rCount = ds.Tables[0].Rows.Count;
            dgCat.SetBinding(TextBox.TextProperty, "SigCatMain");
            dgCat.DataContext = ds.Tables[0].DefaultView;
            int cH = 0;
            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                dgCat.Columns[cH].Header = column.ColumnName;
                cH++;
            }
            //dgCat.Columns[0].Header = "RID";
        }
        private void getSubCats(string tableName)
        {
            ds2 = new DataSet();
            var cn = new SqlConnection(Connections.csSig);
            string sQuery = "Select * from " + tableName;
            da2 = new SqlDataAdapter(sQuery, cn);
            da2.Fill(ds2, tableName);
            int rCount = ds2.Tables[0].Rows.Count;
            dgSubCat.SetBinding(TextBox.TextProperty, tableName);
            dgSubCat.DataContext = ds2.Tables[0].DefaultView;
        }

        private void btUp_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

        }

      
    }
}
