using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace V1.Ultilities
{
    public class ImgPathConverter : IValueConverter // Thêm thư viện using System.Windows.Data;
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int proID = (int)value;
            //return string.Format(@"C:\Users\tuhuy\Desktop\LT LTUDQL2\DoAn\V1\imgs\sp\{0}\main.jpg", proID);
            //C:\Users\tuhuy\Desktop\LT LTUDQL2\DoAn\V1\imgs\sp\{0}\main.jpg
            return string.Format(@"C:\Users\tuhuy\Desktop\LT LTUDQL2\DoAn\V1\imgs\sp\{0}\main.jpg", proID);
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
