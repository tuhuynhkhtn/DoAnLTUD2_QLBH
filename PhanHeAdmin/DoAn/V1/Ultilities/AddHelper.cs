using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using V1.Model;

namespace V1.Ultilities
{
    public class AddHelper
    {
        public static Cart GetCart()
        {
            if (Application.Current.Properties["cart"] == null)
            {
                Application.Current.Properties["cart"] = new Cart();
            }
            return (Cart)Application.Current.Properties["cart"];
        }
    }
}
