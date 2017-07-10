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
using V1.Model;
using V1.UC;

namespace V1
{
    /// <summary>
    /// Interaction logic for FrmQuanTriAdmin.xaml
    /// </summary>
    public partial class FrmQuanTriAdmin : Window
    {
        public FrmQuanTriAdmin()
        {
            InitializeComponent();
            // Hiển thị cửa sổ chính giữa màn hình
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            LoadResource();

        }

        public void LoadResource()
        {
            using (var dc = new QLBH1Entities())
            {
                //Lấy resource
                var db = this.FindResource("myDB") as MyDataContext;
                db.ListPro = dc.Products.ToList();
                db.ListCat = dc.Categories.ToList();
                db.ListNSX = dc.NhaSanXuats.ToList();
                db.ListOrder = dc.Orders
                                 .OrderBy(p => p.OrderDate)
                                 .OrderByDescending(p => p.OrderDate)
                                 .ToList();
                db.ListUser = dc.Users.ToList();

                LoadTruyCapNhanh();

                //DataContext = from o in dc.OrderDetails
                //              from p in dc.Products
                //              from c in dc.Categories
                //              select new
                //              {
                //                  TenLoaiSanPham = c.CatName,
                //                  TongTien = o.Amount
                //              };

                //DataContext = dc.Products
                //    .Join(dc.OrderDetails, p => p.ProID, od => od.ProID, (p, od) => new { p.ProName, od.Amount })
                //    .ToList();

                var query = dc.Products
                            .Join(dc.OrderDetails, p => p.ProID, od => od.ProID, (p, od) =>
                                    new { p.CatID, p.ProName, od.OrderID, od.Amount });
                var q = query.Join(dc.Categories, p => p.CatID, c => c.CatID, (p, c) =>
                                    new { p.CatID, c.CatName, p.OrderID, p.Amount });
                var kq = from q1 in q
                              group q1 by q1.CatName into gr
                              select new
                              {
                                  CatName = gr.Key,
                                  TongTien = gr.Sum(v => v.Amount)
                              };
                DataContext = kq.ToList();
            }
        }

        public void LoadTruyCapNhanh()
        {
            using (var dc = new QLBH1Entities())
            {
                //San pham moi nhat
                var proNew = dc.Products
                               .Where(p => p.BiXoa == 0)
                               .OrderByDescending(p => p.NgayNhap)
                               .Take(10)
                               .ToList();
                lvProNew.ItemsSource = proNew;

                //San pham ban chay nhat
                var proOrder = dc.Products
                                 .Where(p => p.BiXoa == 0)
                                 .OrderByDescending(p => p.SoLuongDaBan)
                                 .Take(10)
                                 .ToList();
                lvProOrder.ItemsSource = proOrder;

                //San pham xem nhieu nhat
                var proView = dc.Products
                                .Where(p => p.BiXoa == 0)
                                .OrderByDescending(p => p.SoLuotXem)
                                .Take(10)
                                .ToList();
                lvProView.ItemsSource = proView;
            }
        }

        private void txtUserID_TextChanged(object sender, TextChangedEventArgs e)
        {
            var userId = int.Parse(txtUserID.Text);
            using (var qlbh = new QLBH1Entities())
            {
                var dc = this.FindResource("myDB") as MyDataContext;
                dc.ListLichSuMuaHang = qlbh.Orders.Where(p => p.UserID == userId).ToList();
            }
        }


        //}
        //private void btnLoadLoaiSanPham_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        var dc = this.FindResource("myDB") as MyDataContext;
        //        dc.ListCat = qlbh.Categories.ToList();
        //    }
        //}
        //private void btnThemLoaiSanPham_Click(object sender, RoutedEventArgs e)
        //{
        //    var cat = new Category { CatName = txtTenLoaiSP.Text };
        //    if (string.IsNullOrEmpty(cat.CatName))
        //    {
        //        MessageBox.Show("Dữ liệu chưa đầy đủ!");
        //        return;
        //    }

        //    // Kiểm tra CatName đã có chưa
        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        int n = qlbh.Categories.Where(m => m.CatName == cat.CatName).Count();
        //        if (n > 0)
        //        {
        //            MessageBox.Show("Tên loại sản phẩm đã tồn tại!");
        //        }
        //        else
        //        {
        //            // Thêm CatName vào database
        //            qlbh.Categories.Add(cat);
        //            if (qlbh.SaveChanges() > 0)
        //            {
        //                MessageBox.Show("Thêm thành công!");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Chưa thêm được!");
        //            }

        //            var dc = this.FindResource("myDB") as MyDataContext;
        //            dc.ListCat = qlbh.Categories.ToList();
        //        }
        //    }
        //}

        //private void btnXoaLoaiSanPham_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        var cat = qlbh.Categories.Where(m => m.CatName == txtTenLoaiSP.Text).Single() as Category;
        //        if (cat == null)
        //        {
        //            MessageBox.Show("Loại sản phẩm không tồn tại!");
        //        }
        //        else
        //        {
        //            qlbh.Categories.Remove(cat);
        //            if (qlbh.SaveChanges() > 0)
        //            {
        //                MessageBox.Show("Xóa thành công!");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Chưa xóa được!");
        //            }

        //            var dc = this.FindResource("myDB") as MyDataContext;
        //            dc.ListCat = qlbh.Categories.ToList();
        //        }
        //    }
        //}

        //private void btnCapNhatLoaiSanPham_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        var cat = new Category { CatID = int.Parse(txtIDLoaiSP.Text), CatName = txtTenLoaiSP.Text };
        //        if (string.IsNullOrEmpty(cat.CatName))
        //        {
        //            MessageBox.Show("Dữ liệu chưa đầy đủ!");
        //            return;
        //        }              

        //        //var n = (qlbh.Categories.Where(m => m.CatName == txtTenLoaiSP.Text).FirstOrDefault() != null) ? qlbh.Categories.Where(m => m.CatName == txtTenLoaiSP.Text).Single() as Category : null;
        //        var n = qlbh.Categories.Where(m => m.CatID == cat.CatID).FirstOrDefault();
        //        if (n != null)
        //        {
        //            n.CatName = cat.CatName;
        //            if (qlbh.SaveChanges() > 0)
        //            {
        //                MessageBox.Show("Sửa thành công");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Chưa sửa được");
        //            }
        //            var dc = this.FindResource("myDB") as MyDataContext;
        //            dc.ListCat = qlbh.Categories.ToList();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Tên loại sản phẩm không tồn tại");
        //        }
        //    }
        //}

        //private void btnThemNSX_Click(object sender, RoutedEventArgs e)
        //{
        //    var nsx = new NhaSanXuat { TenNhaSanXuat = txtTenNSX.Text };
        //    if (string.IsNullOrEmpty(nsx.TenNhaSanXuat))
        //    {
        //        MessageBox.Show("Dữ liệu chưa đầy đủ!");
        //        return;
        //    }

        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        int n = qlbh.NhaSanXuats.Where(m => m.TenNhaSanXuat == nsx.TenNhaSanXuat).Count();
        //        if (n > 0)
        //        {
        //            MessageBox.Show("Tên nhà sản xuất đã tồn tại!");
        //        }
        //        else
        //        {
        //            qlbh.NhaSanXuats.Add(nsx);
        //            if (qlbh.SaveChanges() > 0)
        //            {
        //                MessageBox.Show("Thêm thành công!");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Chưa thêm được!");
        //            }

        //            var dc = this.FindResource("myDB") as MyDataContext;
        //            dc.ListNSX = qlbh.NhaSanXuats.ToList();
        //        }
        //    }
        //}

        //private void btnXoaNSX_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        var nsx = qlbh.NhaSanXuats.Where(m => m.TenNhaSanXuat == txtTenNSX.Text).Single() as NhaSanXuat;
        //        if (nsx == null)
        //        {
        //            MessageBox.Show("Nhà sản xuất không tồn tại!");
        //        }
        //        else
        //        {
        //            qlbh.NhaSanXuats.Remove(nsx);
        //            if (qlbh.SaveChanges() > 0)
        //            {
        //                MessageBox.Show("Xóa thành công!");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Chưa xóa được!");
        //            }

        //            var dc = this.FindResource("myDB") as MyDataContext;
        //            dc.ListNSX = qlbh.NhaSanXuats.ToList();
        //        }
        //    }
        //}

        //private void btnCapNhatNSX_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        var nsx = new NhaSanXuat { IDNhaSanXuat = int.Parse(txtIDNSX.Text), TenNhaSanXuat = txtTenNSX.Text };
        //        if (string.IsNullOrEmpty(nsx.TenNhaSanXuat))
        //        {
        //            MessageBox.Show("Dữ liệu chưa đầy đủ!");
        //            return;
        //        }

        //        var n = qlbh.NhaSanXuats.Where(m => m.IDNhaSanXuat == nsx.IDNhaSanXuat).FirstOrDefault();
        //        if (n != null)
        //        {
        //            n.TenNhaSanXuat = nsx.TenNhaSanXuat;
        //            if (qlbh.SaveChanges() > 0)
        //            {
        //                MessageBox.Show("Sửa thành công");
        //            }
        //            else
        //            {
        //                MessageBox.Show("Chưa sửa được");
        //            }
        //            var dc = this.FindResource("myDB") as MyDataContext;
        //            dc.ListNSX = qlbh.NhaSanXuats.ToList();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Tên nhà sản xuất không tồn tại");
        //        }
        //    }

        //}

        //private void btnDaGiao_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        var order = new Order { OrderID = int.Parse(txtIDDonHang.Text), TinhTrangGiao = int.Parse(txtTinhTrangGiao.Text) };
        //        var n = qlbh.Orders.Where(m => m.OrderID == order.OrderID).FirstOrDefault();
        //        n.TinhTrangGiao = 1;
        //        if (qlbh.SaveChanges() > 0)
        //        {
        //            MessageBox.Show("Sửa thành công");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Chưa sửa được");
        //        }
        //        var dc = this.FindResource("myDB") as MyDataContext;
        //        dc.ListOrder = qlbh.Orders.ToList();
        //    }
        //}

        //private void btnChuaGiao_Click(object sender, RoutedEventArgs e)
        //{
        //    using (var qlbh = new QLBH1Entities())
        //    {
        //        var order = new Order { OrderID = int.Parse(txtIDDonHang.Text), TinhTrangGiao = int.Parse(txtTinhTrangGiao.Text) };
        //        var n = qlbh.Orders.Where(m => m.OrderID == order.OrderID).FirstOrDefault();
        //        n.TinhTrangGiao = 0;
        //        if (qlbh.SaveChanges() > 0)
        //        {
        //            MessageBox.Show("Sửa thành công");
        //        }
        //        else
        //        {
        //            MessageBox.Show("Chưa sửa được");
        //        }
        //        var dc = this.FindResource("myDB") as MyDataContext;
        //        dc.ListOrder = qlbh.Orders.ToList();
        //    }
        //}



    }
}
