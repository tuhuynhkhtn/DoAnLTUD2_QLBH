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
    public class ButtonDeleteNSXCmd : ICommand
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

            int nsxId = int.Parse(values[0].ToString());
            var nsxName = values[1].ToString();

            var nsx = new NhaSanXuat { IDNhaSanXuat = nsxId, TenNhaSanXuat = nsxName };

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

            using (var qlbh = new QLBH1Entities())
            {
                var n = qlbh.NhaSanXuats.Where(m => m.IDNhaSanXuat == nsxId && m.TenNhaSanXuat == nsx.TenNhaSanXuat).FirstOrDefault();
                if (n == null)
                {
                    MessageBox.Show("Nhà sản xuất không tồn tại!");
                }
                else
                {
                    var a = qlbh.NhaSanXuats.Where(m => m.IDNhaSanXuat == nsxId && m.TenNhaSanXuat == nsx.TenNhaSanXuat).FirstOrDefault();
                    qlbh.NhaSanXuats.Remove(a);
                    if (qlbh.SaveChanges() > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Chưa xóa được!");
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
