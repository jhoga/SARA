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

namespace SaraD2
{
    /// <summary>
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        string fName;
        public Password(string formName)
        {
            InitializeComponent();
            fName = formName;
        }

        private void  btSub_Click(object sender, RoutedEventArgs e)
        {
            checkPassword();
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                checkPassword();
                //MessageBox.Show("Enter pressed");
            }

        }
        private void checkPassword()
        {
            //var pas = new PasswordAuth();
            //if (passwordBox.Password == "PinkCows29")
            if (passwordBox.Password == "123")
            {
                //pas.Intpass = 1;
                switch (fName)
                {
                    case "Departments":
                        var dep = new Departments();
                        dep.Show();
                        this.Close();
                        break;
                    case "Categories":
                        var ITC = new ITCat();
                        ITC.Show();
                        this.Close();
                        break;
                    case "ITEmails":
                        var ITE = new ITEmails();
                        ITE.Show();
                        this.Close();
                        break;
                    default:
                        return;

                }

            }
            else
            {
                MessageBox.Show("You entered the wrong password! No soup for you!");
                return;
            }
            //return pas.Intpass;
        }



    }
}
