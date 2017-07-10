using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using V1.UC;

namespace V1.Commands
{
    public class ButtonLeftCatCmd : ICommand // Thêm using System.Windows.Input;
    {
        // Event này kích hoạt mỗi khi có một sự thay đổi làm ảnh hưởng tới command. Các control sử dụng command sẽ được enable/disable tùy theo kết quả trả về của CanExecute().
        public event EventHandler CanExecuteChanged;

        // Phương thức này xác định command có thể được thực thi hay không. Giá trị trả về của phương thức này (boolean) sẽ ảnh hưởng đến property Enabled của các control liên quan đến command.
        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Phương thức này sẽ thực thi khi command được kích hoạt.
        public void Execute(object parameter)
        {
            int catID = int.Parse(parameter.ToString());

            MainWindow m = (MainWindow)Application.Current.MainWindow;

            UCListProductByCat l = new UCListProductByCat(catID);

            m.ListProductByCat(l);
        }
    }
}
