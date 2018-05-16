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
using System.Net.Mail;




namespace SaraD2
{
    /// <summary>
    /// Interaction logic for InfoTech.xaml
    /// </summary>
    public partial class InfoTech : Window
    {
        DataSet ds;
        public string slevel = "";
        public InfoTech()
        {
            InitializeComponent();
            get_Departments();
            get_Categories();

        }

        public void get_Departments()
        {
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            ds = getList.get_ITCatData("Departments");
            rCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = ds.Tables[0].Rows[i].Field<string>("Department");
                cbDep.Items.Add(valTest);

            }

        }
        public void get_Categories()
        {
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            ds = getList.get_ITCatData("ITCatMain");
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
            cbsCat.Items.Clear();
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            string strCat = (cbCat.Text.Trim());
            string tInd = cbCat.SelectedIndex.ToString();
            switch (tInd)
            {
                case "0":
                    ds = getList.get_ITCatData("ITc1");
                    break;
                case "1":
                    ds = getList.get_ITCatData("ITc2");
                    break;
                case "2":
                    ds = getList.get_ITCatData("ITc3");
                    break;
                case "3":
                    ds = getList.get_ITCatData("ITc4");
                    break;
                case "4":
                    ds = getList.get_ITCatData("ITc5");
                    break;
                case "5":
                    ds = getList.get_ITCatData("ITc6");
                    break;
                case "6":
                    ds = getList.get_ITCatData("ITc7");
                    break;
                default:
                    ds = getList.get_ITCatData("ITc1");
                    break;
            }
            rCount = ds.Tables[0].Rows.Count;
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = ds.Tables[0].Rows[i].Field<string>("Description");
                cbsCat.Items.Add(valTest);

            }


        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            tbName.Text = "";
            tbEmail.Text = "";
            tbTel.Text = "";
            cbDep.Text = "";
            cbCat.Text = "";
            cbsCat.Text = "";
            tbcNum.Text = "";
            tbDes.Text = "";
        }
        public void SubmitData()
        {
            string[] arr = new string[11];
            string dVal = DateTime.Now.ToString();
            arr[0] = dVal;
            arr[1] = (tbName.Text).Trim();
            arr[2] = (tbEmail.Text).Trim();
            arr[3] = "Not Started";
            arr[4] = (cbDep.Text).Trim();
            arr[5] = (cbCat.Text).Trim();
            arr[6] = (cbsCat.Text).Trim();
            arr[7] = (tbcNum.Text).Trim();
            arr[8] = slevel;
            arr[9] = (tbTel.Text).Trim();
            arr[10] = (tbDes.Text).Trim();

            var dr = new DataRepository();
            dr.add_NewIT(arr);
            this.Close();
        }

        private void btSum_Click(object sender, RoutedEventArgs e)
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
            if (tbTel.Text.Length < 4)
            {
                MessageBox.Show("TELEPHONE MUST BE ENTERED");
                return;
            }
            if (tbDes.Text.Length < 3)
            {
                MessageBox.Show("Request MUST BE ENTERED");
                return;
            }
            string cat1 = cbCat.Text;
            try
            {
                sendEmail(cat1);
            }
            catch { }//need to add error handling email here
            try
            {
                SubmitData();
                MessageBox.Show("Thank you for your submission.");
            }
            catch { MessageBox.Show("An error occured in your submission please contact IT at 5327"); }
            ClearAll();
        }
        private void sendEmail(string cat)
        {
            var getList = new DataRepository();
            string category = cbCat.Text;
            string tInd = cbCat.SelectedIndex.ToString();
            switch (tInd)
            {
                case "0":
                    ds = getList.get_ITRes("ITc1");
                    break;
                case "1":
                    ds = getList.get_ITRes("ITc2");
                    break;
                case "2":
                    ds = getList.get_ITRes("ITc3");
                    break;
                case "3":
                    ds = getList.get_ITRes("ITc4");
                    break;
                case "4":
                    ds = getList.get_ITRes("ITc5");
                    break;
                case "5":
                    ds = getList.get_ITRes("ITc6");
                    break;
                case "6":
                    ds = getList.get_ITRes("ITc7");
                    break;


                default:
                    ds = getList.get_ITRes("ITc1");
                    break;
            }
            int rCount;
            rCount = ds.Tables[0].Rows.Count;
            //string strTo;
            string strFrom = "noreply@Salisburync.gov";
            string strTo = "jhoga@salisburync.gov";
            MailMessage myMessage = new MailMessage(strFrom, strTo);
            for (int i = 0; i <= rCount - 1; i++)
            {
                string valTest = ds.Tables[0].Rows[i].Field<string>("Email");
                myMessage.To.Add(valTest);
                Console.WriteLine(valTest);

            }

            //string strFrom = "SaraD2@Salisburync.gov";
            //string strTo = "jhoga@salisburync.gov";
            //MailMessage myMessage = new MailMessage(strFrom, strTo);
            //myMessage.To.Add("mover@salisburync.gov");
            SmtpClient myMail = new SmtpClient("10.0.0.160");
            DataSet dsMax = new DataSet();

            dsMax = getList.getMax();
            int strNum = dsMax.Tables[0].Rows[0].Field<int>("ID");

            string bString = @"New ticket: " + strNum + "\n" + "From: " + tbName.Text + "\n" + "Telephone: " + tbTel.Text + "\n" + "Category: " + cbCat.Text + "\n" + "Sub-Cat: " + cbsCat.Text + "\n";
            bString += "Department: " + cbDep.Text + "\n" + "Computer: " + tbcNum.Text + "\n" + "Description: " + tbDes.Text;
            myMessage.Subject = "SARA Ticket";
            myMessage.Body = bString;
            try
            {
                myMail.Send(myMessage);
            }
            catch { }
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


        private void Departments_Click(object sender, RoutedEventArgs e)
        {
            var pas = new Password("Departments");
            pas.Show();
            //var Dep = new Departments();
            //Dep.Show();
            //this.Close();

        }

        private void Cat_click(object sender, RoutedEventArgs e)
        {
            var pas = new Password("Categories");
            pas.Show();
            //var ITC = new ITCat();
            //ITC.Show();
        }

        private void TechEmails_click(object sender, RoutedEventArgs e)
        {
            var pas = new Password("ITEmails");
            pas.Show();
            //var ITE = new ITEmails();
            //ITE.Show();
        }


    }
}
