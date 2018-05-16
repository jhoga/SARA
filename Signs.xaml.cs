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

namespace SaraD2
{
    /// <summary>
    /// Interaction logic for Signs.xaml
    /// </summary>
    public partial class Signs : Window
    {
        DataSet ds;
        SqlDataAdapter da;
        public Signs()
        {
            InitializeComponent();
            get_Categories();

        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            tbName.Text = "";
            tbAdd.Text = "";
            tbReq.Text = "";
            cbCat.Text = "";

        }


        private void Cat_Click(object sender, RoutedEventArgs e)
        {

            var sc = new SignCat();
            sc.Show();
        }

        private void Email_Click(object sender, RoutedEventArgs e)
        {
            var se = new SignEmails();
            se.Show();
        }
        public void get_Categories()
        {
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            ds = getList.get_sigCatData("SignCatMain");
            rCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = (ds.Tables[0].Rows[i].Field<string>("Description")).Trim();

                if (valTest != "UserDef")
                {
                    cbCat.Items.Add(valTest);
                }


            }
        }

        private void cbCat_DropDownClosed(object sender, EventArgs e)
        {
           cbSubCat.Items.Clear();
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            string indCheck = cbCat.SelectedIndex.ToString();

            switch (indCheck)
            {
                case "0":
                    ds = getList.get_signCatData("SignCat1");
                    break;
                case "1":
                    ds = getList.get_signCatData("SignCat2");
                    break;
                case "2":
                    ds = getList.get_signCatData("SignCat3");
                    break;
                case "3":
                    ds = getList.get_signCatData("SignCat4");
                    break;
                case "4":
                    ds = getList.get_signCatData("SignCat5");
                    break;
                case "5":
                    ds = getList.get_signCatData("SignCat6");
                    break;
                case "6":
                    ds = getList.get_signCatData("SignCat7");
                    break;
                case "7":
                    ds = getList.get_signCatData("SignCat8");
                    break;
                case "8":
                    ds = getList.get_signCatData("SignCat9");
                    break;

                default:
                    ds = getList.get_signCatData("SignCat1");
                    break;
            }
            rCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = ds.Tables[0].Rows[i].Field<string>("Description");
                cbSubCat.Items.Add(valTest);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SubSigns_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
