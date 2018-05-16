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

namespace SaraD2
{
    /// <summary>
    /// Interaction logic for Facilities.xaml
    /// </summary>
    public partial class Facilities : Window
    {
        public string slevel = "";
        public Facilities()
        {
            InitializeComponent();
            get_Locations();
            get_Categories();
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }
        public void clear()
        {
            tbName.Text = "";
            tbEmail.Text = "";
            cbLoc.Text = "";
            cbCat.Text = "";
            tbReq.Text = "";

        }

      
        public void get_Locations()
        {
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            ds = getList.get_Locations();
            rCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = ds.Tables[0].Rows[i].Field<string>("Location");
                cbLoc.Items.Add(valTest);

            }
        }

       public void get_Categories()
        {
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            ds = getList.get_FacTables("FacCatMain");
            rCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = (ds.Tables[0].Rows[i].Field<string>("Description").Trim());
                if (valTest != "UserDef")
                {
                    cbCat.Items.Add(valTest);
                }

                

            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Locations_Click(object sender, RoutedEventArgs e)
        {
            //var pas = new Password("Departments");
            //pas.Show();
            var Loc = new Locations();
            Loc.Show();
            this.Close();
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            var fCat = new FacCat();
            fCat.Show();
            this.Close();
        }

        private void Emails_Click(object sender, RoutedEventArgs e)
        {
            //var pas = new Password("ITEmails");
            //pas.Show();
            var FAC = new FACEmails();
            FAC.Show();
        }

        private void cbCat_DropDownClosed(object sender, EventArgs e)
        {
            cbSubCat.Items.Clear();
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            string strCat = (cbCat.Text.Trim());
            string tInd = cbCat.SelectedIndex.ToString();
            switch (tInd)
            {
                case "0":
                    ds = getList.get_FacTables("FACc1");
                    break;
                case "1":
                    ds = getList.get_FacTables("FACc2");
                    break;
                case "2":
                    ds = getList.get_FacTables("FACc3");
                    break;
                case "3":
                    ds = getList.get_FacTables("FACc4");
                    break;
                case "4":
                    ds = getList.get_FacTables("FACc5");
                    break;
                case "5":
                    ds = getList.get_FacTables("FACc6");
                    break;
                case "6":
                    ds = getList.get_FacTables("FACc7");
                    break;
                case "7":
                    ds = getList.get_FacTables("FACc8");
                    break;
                case "8":
                    ds = getList.get_FacTables("FACc9");
                    break;
                case "9":
                    ds = getList.get_FacTables("FACc10");
                    break;
                default:
                    ds = getList.get_FacTables("FACc1");
                    break;
            }
            rCount = ds.Tables[0].Rows.Count;
            cbSubCat.Items.Clear();
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = ds.Tables[0].Rows[i].Field<string>("Description");
                              
                    cbSubCat.Items.Add(valTest);
               

            }

        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (tbName.Text.Length < 2)
            {
                MessageBox.Show("NAME MUST BE ENTERED");
                return;
            }
            if (tbEmail.Text.Contains("@salisburync.gov") == false)
            {
                MessageBox.Show("EMAIL MUST BE ENTERED");
                return;
            }
            if (cbLoc.Text.Length < 2)
            {
                MessageBox.Show("LOCATION MUST BE ENTERED");
                return;
            }
            if (cbCat.Text.Length < 2)
            {
                MessageBox.Show("CATEGORY MUST BE ENTERED");
                return;
            }
            if (tbReq.Text.Length < 2)
            {
                MessageBox.Show("REQUEST MUST BE ENTERED");
                return;
            }
            SubmitData();
        }
        public void SubmitData()
        {
            string[] arr = new string[11];
            string dVal = DateTime.Now.ToString();
            arr[0] = dVal;
            arr[1] = (tbName.Text).Trim();
            arr[2] = (tbEmail.Text).Trim();
            arr[3] = (cbLoc.Text).Trim();
            arr[4] = (cbCat.Text).Trim();
            arr[5] = (cbSubCat.Text).Trim();
            arr[6] = (tbReq.Text).Trim();
            arr[7] = slevel;
          

            var dr = new DataRepository();
            dr.add_NewFAC(arr);
            this.Close();
        }

        private void RadioButton1_Checked(object sender, RoutedEventArgs e)
        {
            slevel = "1";
        }

        private void RadioButton2_Checked(object sender, RoutedEventArgs e)
        {
            slevel = "2";
        }

        private void RadioButton3_Checked(object sender, RoutedEventArgs e)
        {
            slevel = "3";
        }

        private void RadioButton4_Checked(object sender, RoutedEventArgs e)
        {
            slevel = "4";
        }
    }
}
