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
    public class ButtonDeleteCatCmd : ICommand
    {
        //Regular
        private static string rgCatName = @"^[a-zA-Z -]{1,30}$";

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var values = (object[])parameter;

            int catId = int.Parse(values[0].ToString());
            var catName = values[1].ToString();

            //var catName = values[0].ToString();

            var cat = new Category { CatID = catId, CatName = catName };

            if ((string.IsNullOrEmpty(cat.CatName)) || (!Regex.IsMatch(cat.CatName, rgCatName)))
            {
                if (string.IsNullOrEmpty(cat.CatName))
                {
                    MessageBox.Show("Nhập tên loại sản phẩm!");
                    return;
                }

                if (!Regex.IsMatch(cat.CatName, rgCatName))
                {
                    MessageBox.Show("Nhập chữ, 1-30 ký tự");
                    return;
                }
            }

            using (var qlbh = new QLBH1Entities())
            {
                
                var n = qlbh.Categories.Where(m => m.CatID == catId && m.CatName == catName).FirstOrDefault();
                if (n == null)
                {
                    MessageBox.Show("Loại sản phẩm không tồn tại!");
                }
                else
                {
                    var c = qlbh.Categories.Where(m => m.CatID == catId && m.CatName == catName).FirstOrDefault();
                    qlbh.Categories.Remove(c); 
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
                    dc.ListCat = qlbh.Categories.ToList();

                    //load lai danh sach
                    FrmQuanTriAdmin f = (FrmQuanTriAdmin)Application.Current.MainWindow;
                    f.LoadResource();
                }
            }
        }

    }
}
