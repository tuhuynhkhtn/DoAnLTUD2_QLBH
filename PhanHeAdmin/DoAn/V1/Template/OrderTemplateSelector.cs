using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using V1.Model;

namespace V1.Template
{
    class OrderTemplateSelector: DataTemplateSelector // Thêm thư viện using System.Windows.Controls;
    {
        public DataTemplate DefaultTemplate { get; set; } // Thêm thư viện using System.Windows;
        public DataTemplate HighlightTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var order  = item as Order;
            if (order.TinhTrangGiao > 0)
            {
                return DefaultTemplate;
            }
            return HighlightTemplate;
        }
    }
}
