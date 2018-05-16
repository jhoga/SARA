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
using SaraD2.Class;

namespace SaraD2
{
    /// <summary>
    /// Interaction logic for Signals.xaml
    /// </summary>
    public partial class Signals : Window
    {
        public Signals()
        {
            InitializeComponent();
            get_Categories();
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
           cbSigCat.Items.Clear();
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            string sigInd = cbSignal.SelectedIndex.ToString();
            switch (sigInd)
            {
                case "0":
                    ds = getList.get_sigCatData("SigCat1");
                    break;
                case "1":
                    ds = getList.get_sigCatData("SigCat2");
                    break;
                case "2":
                    ds = getList.get_sigCatData("SigCat3");
                    break;
                case "3":
                    ds = getList.get_sigCatData("SigCat4");
                    break;
              

                default:
                    ds = getList.get_sigCatData("SigCat1");
                       break;

            }
            rCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = ds.Tables[0].Rows[i].Field<string>("Description");
                cbSigCat.Items.Add(valTest);

            }

        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            tbName.Text = "";
            tbEmail.Text = "";
            tbLoc.Text = "";
            tbTel.Text = "";
            cbSignal.Text = "";
            cbSigCat.Text = "";
            tbReq.Text = "";
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            var sc = new SigCat();
            sc.Show();
        }

        private void Emails_Click(object sender, RoutedEventArgs e)
        {
            var se = new SigEmails();
            se.Show();
        }
        public void get_Categories()
        {
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            ds = getList.get_sigCatData("SigCatMain");
            rCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = (ds.Tables[0].Rows[i].Field<string>("Description")).Trim();

                if (valTest != "UserDef")
                {
                    cbSignal.Items.Add(valTest);
                }


            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
