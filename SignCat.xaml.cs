﻿using System;
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
    /// Interaction logic for SignCat.xaml
    /// </summary>
    public partial class SignCat : Window
    {
        DataSet ds;
        SqlDataAdapter da;
        DataSet ds2;
        SqlDataAdapter da2;
        SqlCommandBuilder cmd1;
        SqlCommandBuilder cmd2;
        string subCatTable;
        public SignCat()
        {
            InitializeComponent();
            getCats();
        }

        private void btUp_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {

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
        private void getCats()
        {

            ds = new DataSet();
            var cn = new SqlConnection(Connections.csSign);
            string sQuery = "Select * from SignCatMain";
            da = new SqlDataAdapter(sQuery, cn);
            da.Fill(ds, "SignCatMain");
            int rCount = ds.Tables[0].Rows.Count;
            dgCat.SetBinding(TextBox.TextProperty, "SignCatMain");
            dgCat.DataContext = ds.Tables[0].DefaultView;
            int cH = 0;
            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                dgCat.Columns[cH].Header = column.ColumnName;
                cH++;
            }
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


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cmd1 = new SqlCommandBuilder(da);
                da.Update(ds, "SignCatMain");
                MessageBox.Show("Database updated", "Update", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
