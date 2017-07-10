using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace V1.Commands
{
    public class ButtonBuyListCmd : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //proID, Quantity = 1 default
            int proID = int.Parse(parameter.ToString());
            MessageBox.Show(proID.ToString());
        }
    }
}
