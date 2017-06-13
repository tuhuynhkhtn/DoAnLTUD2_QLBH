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
using V1;

namespace V1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            using (var qlbh = new QLBHEntities())
            {
                lvCat.ItemsSource = qlbh.Categories.ToList();
                
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            gr.Children.Clear();
            UCLogin us = new UCLogin();
            gr.Children.Add(us);
        }

        private void btbRegister_Click(object sender, RoutedEventArgs e)
        {
            gr.Children.Clear();
            UCRegister ucReg = new UCRegister(); ;
            gr.Children.Add(ucReg);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gr.Children.Clear();
            var btn = sender as Button;
            int catID = ((int)btn.Tag);
            using (var qlbh = new QLBHEntities())
            {
                //List<Products> list = qlbh.Products.Where(p => p.CatID == catID).ToList();
                UCListProductByCat ucPro = new UCListProductByCat(catID);
                gr.Children.Add(ucPro);
            }
        }
    }
}
