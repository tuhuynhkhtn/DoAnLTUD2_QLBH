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
using V1.Page;

namespace V1.UC
{
    /// <summary>
    /// Interaction logic for UCListProductByCat.xaml
    /// </summary>
    public partial class UCListProductByCat : UserControl
    {
        public static int cat = 0;
        QLBH1Entities qlbh = new QLBH1Entities();

        public UCListProductByCat()
        {
            InitializeComponent();
        }

        public UCListProductByCat(int catID)
        {
            InitializeComponent();
            cat = catID;
            var db = this.FindResource("dbForWd") as PageListProduct;
            int totalPage;
            db.CurPage = 1;
            db.Products = GetListProduct(catID, db.CurPage, PageListProduct.PageSize, out totalPage);
            db.TotalPage = totalPage;

            if (totalPage == 0)
            {
                db.CurPage = 0;
            }

            lvPro.ItemsSource = db.Products;
            DataContext = db.Products.ToList();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            int catID = cat;

            //int page = ((int)btn.Tag);
            //
            var db = this.FindResource("dbForWd") as PageListProduct;
            if (db.CurPage == db.TotalPage)
            {
                return;
            }
            int totalPage;
            int cur = db.CurPage + 1;
            db.Products = GetListProduct(catID, cur, PageListProduct.PageSize, out totalPage);
            db.CurPage++;
            db.TotalPage = totalPage;

            //Update data
            lvPro.ItemsSource = db.Products;
            DataContext = db.Products.ToList();
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            int catID = ((int)btn.Tag);
            //
            var db = this.FindResource("dbForWd") as PageListProduct;
            if (db.CurPage == 1)
            {
                return;
            }
            int totalPage;
            int cur = db.CurPage - 1;
            db.Products = GetListProduct(catID, cur, PageListProduct.PageSize, out totalPage);
            db.CurPage--;
            db.TotalPage = totalPage;
            if (db.CurPage == db.TotalPage)
            {
                return;
            }
            //Update data
            lvPro.ItemsSource = db.Products;
            DataContext = db.Products.ToList();
        }

        List<Product> GetListProduct(int catID, int curPage, int pageSize, out int totalPage)
        {
            IQueryable<Product> q = qlbh.Products;
            q = q.Where(p => p.CatID == catID);

            totalPage = (int)Math.Ceiling(q.Count() * 1.0 / pageSize); // Math.Ceiling: Làm tròn số lên số nguyên gần nhất.

            return q.OrderBy(p => p.ProName)
                .Skip((curPage - 1) * pageSize)
                .Take(pageSize).ToList();
        }
    }
}
