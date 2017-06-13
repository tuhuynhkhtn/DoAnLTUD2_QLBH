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
    public class ButtonLeftProCmd  :ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            int idNSX = int.Parse(parameter.ToString());

            MainWindow m = (MainWindow)Application.Current.MainWindow;

            UCListProductByNSX l = new UCListProductByNSX(idNSX);

            m.ListProductByNSX(l);
        }
    }
}
