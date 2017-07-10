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
using V1.Model;

namespace V1.UC
{
    /// <summary>
    /// Interaction logic for UCLeft.xaml
    /// </summary>
    public partial class UCLeft : UserControl
    {
        public UCLeft()
        {
            InitializeComponent();

            using (var dc = new QLBH1Entities())
            {
                lvCat.ItemsSource = dc.Categories.ToList();
                lvPro.ItemsSource = dc.NhaSanXuats.ToList();
            }
        }
    }
}
