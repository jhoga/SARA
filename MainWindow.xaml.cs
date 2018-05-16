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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SaraD2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void btIT_MouseEnter(object sender, MouseEventArgs e)
        {
            tbDesc.Text = "InfoTech is used for issues concering Information Technologies.  This includes coumputers, software, TV's, monitors network and file sharing.";
        }

        private void btFacilites_MouseEnter(object sender, MouseEventArgs e)
        {
            tbDesc.Text = "Facilities is used for issues concering Facilities Management.  This includes physical issues concerning buildings,electrical, plumbing, moving, carpentry, painting, leaks, event setups, and general maintenance. It is administered by Public Services.";
        }

       

        private void btSig_MouseEnter(object sender, MouseEventArgs e)
        {
            tbDesc.Text = "Signals/Lights is used for issues concerning Traffic Signals and Street & Parking lot lights. This includes traffic lights maintained by the City of Salisbury. It also includes street, parking lot, and festoon lighting owned by the City of Salisbury. It is administered by Engineering. All emergency requests (dangerous/hazardous situations) for traffic signals or a street light is preferred to go through 911. ";
        }

        private void btSM_MouseEnter(object sender, MouseEventArgs e)
        {
            tbDesc.Text = "Signs/Markings is used for issues concering street signs, traffic signs, informational signs and markings.  This includes parking, directional and zoning signs. It is administered by Public Services.";
        }

        private void btSW_MouseEnter(object sender, MouseEventArgs e)
        {
            tbDesc.Text = "Storm Water is used for inputing strom water information.  It is administered by Public Services.";
        }

        private void btSig_Click(object sender, RoutedEventArgs e)
        {
            var Sig = new Signals();
            Sig.Show();
        }

        private void btIT_Click(object sender, RoutedEventArgs e)
        {
            var IT = new InfoTech();
            IT.Show();
        }

        private void btFacilites_Click(object sender, RoutedEventArgs e)
        {
            var Fac = new Facilities();
            Fac.Show();
        }

        private void btSM_Click(object sender, RoutedEventArgs e)
        {
            var Sign = new Signs();
            Sign.Show();
        }

        private void btSW_Click(object sender, RoutedEventArgs e)
        {
            var Storm = new StormWater();
            Storm.Show();

        }

        private void btFE_Click(object sender, RoutedEventArgs e)
        {
            var Fire = new FireEquip();
            Fire.Show();
        }

        private void btFE_MouseEnter(object sender, MouseEventArgs e)
        {
            tbDesc.Text = "Fire Equipment is used for inputing fire depart equipment issues information.  It is administered by the Fire Department.";
        }

        private void btMedia_Click(object sender, RoutedEventArgs e)
        {
            var Med = new Media();
            Med.Show();
        }

        private void btMedia_MouseEnter(object sender, MouseEventArgs e)
        {
            tbDesc.Text = "Media is used for Public Information video recording request.";
        }
    }
}
