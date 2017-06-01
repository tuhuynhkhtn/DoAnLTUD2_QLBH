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

namespace V1
{
    /// <summary>
    /// Interaction logic for UCListProductByCat.xaml
    /// </summary>
    public partial class UCListProductByCat : UserControl
    {
        public UCListProductByCat(int catID)
        {
            InitializeComponent();

            using (var qlbh = new QLBHEntities())
            {
                List<Products> list = qlbh.Products.Where(p => p.CatID == catID).ToList();
                lvPro.ItemsSource = list;
            }
        }
    }
}
