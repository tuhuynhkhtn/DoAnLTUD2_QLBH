using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using V1.Model;

namespace V1.Commands
{
    public class ButtonAddNSXCmd : ICommand
    {
        //Regular
        private static string rgNSXName = @"^[a-zA-Z -]{1,30}$";

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;

            var TenNSX = values[0].ToString();

            var nsx = new NhaSanXuat { TenNhaSanXuat = TenNSX };

            if ((string.IsNullOrEmpty(nsx.TenNhaSanXuat)) || (!Regex.IsMatch(nsx.TenNhaSanXuat, rgNSXName)))
            {
                if (string.IsNullOrEmpty(nsx.TenNhaSanXuat))
                {
                    MessageBox.Show("Nhập tên nhà sản xuất!");
                    return;
                }

                if (!Regex.IsMatch(nsx.TenNhaSanXuat, rgNSXName))
                {
                    MessageBox.Show("Nhập chữ, 1-30 ký tự");
                    return;
                }
            }

            // Kiểm tra nsxName đã có chưa
            using (var qlbh = new QLBH1Entities())
            {
                int n = qlbh.NhaSanXuats.Where(m => m.TenNhaSanXuat == nsx.TenNhaSanXuat).Count();
                if (n > 0)
                {
                    MessageBox.Show("Nhà sản xuất đã tồn tại!");
                }
                else
                {
                    // Thêm nsxName vào database
                    qlbh.NhaSanXuats.Add(nsx);
                    if (qlbh.SaveChanges() > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Chưa thêm được!");
                    }

                    //var dc = this.FindResource("myDB") as MyDataContext;
                    MyDataContext dc = new MyDataContext();
                    dc.ListNSX = qlbh.NhaSanXuats.ToList();

                    //load lai danh sach
                    FrmQuanTriAdmin f = (FrmQuanTriAdmin)Application.Current.MainWindow;
                    f.LoadResource();
                }
            }

        }
    }
}
