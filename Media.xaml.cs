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
    /// Interaction logic for Media.xaml
    /// </summary>
    public partial class Media : Window
    {
        public Media()
        {
            InitializeComponent();
        }

        private void cbTN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.cbTN.SelectedIndex == 0)
            {
                tbTelYes.Visibility = Visibility.Visible;
            }
           else
            {
                tbTelYes.Visibility = Visibility.Hidden;
            }
        }

        private void btSubVid_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btClear_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
