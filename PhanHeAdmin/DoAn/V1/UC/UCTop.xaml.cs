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
using V1.Ultilities;

namespace V1.UC
{
    /// <summary>
    /// Interaction logic for UCTop.xaml
    /// </summary>
    public partial class UCTop : UserControl
    {
        private static Cart cart;

        public UCTop()
        {
            InitializeComponent();
            cart = AddHelper.GetCart();
            DataContext = cart;
        }

        public UCTop(Cart c)
        {
            cart = AddHelper.GetCart();
            InitializeComponent();

            cart.AddItem(int.Parse(c.ProID), int.Parse(c.Quantity));

            DataContext = cart;

            //Danh sach cua Cart
            //OK
            for (int i = 0; i < cart.Items.Count; i++)
            {
                MessageBox.Show(cart.Items[i].Products.ProID + " = " + cart.Items[i].Quantity);
            }
        }

        private void btnQuanTri_Click(object sender, RoutedEventArgs e)
        {
            FrmQuanTriAdmin frmQuanTriAdmin = new FrmQuanTriAdmin();
            frmQuanTriAdmin.Show();
        }
    }
}
