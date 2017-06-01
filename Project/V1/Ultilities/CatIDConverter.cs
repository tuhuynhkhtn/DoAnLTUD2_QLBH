using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace V1.Ultilities
{
    public class CatIDConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        CultureInfo culture)
        {
            int catID = (int)value;
            bool empty = false;
            using (var qlbh = new QLBHEntities())
            {
                empty = qlbh.Products.Where(p => p.CatID == catID).Count() == 0;
            }
            return empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
