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
using V1.UC;

namespace V1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        //Add Cart
        //List<Cart> listcart = new List<Cart>()

        public MainWindow()
        {
            InitializeComponent();

            // Hiển thị cửa sổ chính giữa màn hình
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //Load categories
            UCLeft ucLeft = new UCLeft();
            grLeft.Children.Add(ucLeft);

            //Top
            UCTop ucTop= new UCTop();
            grTop.Children.Add(ucTop);

        }

        //List product by category
        public void ListProductByCat(UCListProductByCat ucPro)
        {
            grRight.Children.Clear();
            grRight.Children.Add(ucPro);
        }

        //List product by NhaSanxuat
        public void ListProductByNSX(UCListProductByNSX ucPro)
        {
            grRight.Children.Clear();
            grRight.Children.Add(ucPro);
        }

        //Detail
        public void DetailProduct(UCDetail ucDetail)
        {
            grRight.Children.Clear();
            grRight.Children.Add(ucDetail);
        }

        //Add product to Cart
        public void AddProductToCart(Cart cart)
        {
            UCTop ucTop = new UCTop(cart);
            grTop.Children.Clear();
            grTop.Children.Add(ucTop);

            //int i = (int)Application.Current.Properties["cart"];
            //MessageBox.Show(i.ToString());
        }
    }
}
