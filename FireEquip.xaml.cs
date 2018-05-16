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
    /// Interaction logic for FireEquip.xaml
    /// </summary>
    public partial class FireEquip : Window
    {
        public FireEquip()
        {
            InitializeComponent();
        }

        private void cbCat_DropDownClosed(object sender, EventArgs e)
        {
            cbsCat.Items.Clear();
            var ds = new DataSet();
            var getList = new DataRepository();
            int rCount;
            switch (cbCat.Text)
            {
                case "Training":
                    ds = getList.get_FireCatData("FireCat1");
                    break;
                case "FD Software":
                    ds = getList.get_FireCatData("FireCat2");
                    break;
                case "Station Supplies":
                    ds = getList.get_FireCatData("FireCat3");
                    break;
                case "Apparatus":
                    ds = getList.get_FireCatData("FireCat4");
                    break;
                case "SCBA":
                    ds = getList.get_FireCatData("FireCat5");
                    break;
                case "Tools and Equipment":
                    ds = getList.get_FireCatData("FireCat6");
                    break;
                case "Uniforms/PPE":
                    ds = getList.get_FireCatData("FireCat7");
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
            tbName.Text = "";
            tbEmail.Text = "";
            tbTel.Text = "";
            cbDep.Text = "";
            cbCat.Text = "";
            cbsCat.Text = "";
            tbDes.Text = "";
        }
    }
}
