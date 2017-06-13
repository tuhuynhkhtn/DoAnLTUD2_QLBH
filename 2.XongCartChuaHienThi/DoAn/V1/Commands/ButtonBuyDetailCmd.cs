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
    public class ButtonBuyDetailCmd : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var values = (object[])parameter;

            //int quantity = int.Parse(values[0].ToString());

            int quantity;
            int proID = int.Parse(values[1].ToString());

            if (!int.TryParse(values[0].ToString(), out quantity))
            {
                quantity = 0;
                return;
            }
            quantity = int.Parse(values[0].ToString());
            if(quantity > 20 || quantity < 1)
            {
                return;
            }
            MainWindow m = (MainWindow)Application.Current.MainWindow;

            Cart cart = new Cart();
            cart.ProID = proID.ToString();
            cart.Quantity = quantity.ToString();

            m.AddProductToCart(cart);

        }
    }
}
