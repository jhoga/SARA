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

namespace SaraD2
{
    /// <summary>
    /// Interaction logic for StormWater.xaml
    /// </summary>
    public partial class StormWater : Window
    {
        public StormWater()
        {
            InitializeComponent();
        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            tbName.Text = "";
            tbEmail.Text = "";
            tbNum.Text = "";
            tbPhone.Text = "";
            tbPID.Text = "";
            tbRequest.Text = "";
            cbDir.Text = "";
            cbSuf.Text = "";
        }
    }
}
