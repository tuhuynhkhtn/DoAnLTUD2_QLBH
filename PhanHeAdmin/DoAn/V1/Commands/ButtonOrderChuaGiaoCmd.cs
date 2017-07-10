using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using V1.Model;

namespace V1.Commands
{
    public class ButtonOrderChuaGiaoCmd : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;

            int orderId = int.Parse(values[0].ToString());
            var orderTinhTrangGiao = values[1].ToString();

            if (orderTinhTrangGiao == "Chưa giao")
            {
                MessageBox.Show("Đơn hàng này hiện là chưa giao");
                return;
            }

            using (var qlbh = new QLBH1Entities())
            {
                //var order = new Order { OrderID = int.Parse(txtIDDonHang.Text), TinhTrangGiao = int.Parse(txtTinhTrangGiao.Text) };
                var n = qlbh.Orders.Where(m => m.OrderID == orderId).FirstOrDefault();
                n.TinhTrangGiao = 0;
                if (qlbh.SaveChanges() > 0)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Chưa sửa được");
                }

                //var dc = this.FindResource("myDB") as MyDataContext;
                MyDataContext dc = new MyDataContext();
                dc.ListOrder = qlbh.Orders.ToList();

                //load lai danh sach
                FrmQuanTriAdmin f = (FrmQuanTriAdmin)Application.Current.MainWindow;
                f.LoadResource();
            }
        }
    }
}
