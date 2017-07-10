using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using V1.Model;

namespace V1.Ultilities
{
    public class ProIDConverter : IValueConverter
    {
        // Converter: https://yinyangit.wordpress.com/2011/09/10/wpf-data-binding-chuyen-doi-du-lieu-voi-ivalueconverter/
        // value: Giá trị cần chuyển đổi lấy từ binding source.
        // targetType: Kiểu dữ liệu của binding target property.
        // parameter: Tham số cần thiết
        // culture: để áp dụng định dạng với mỗi nền văn hóa khác nhau.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int proID = (int)value;
            bool empty = false;
            using (var qlbh = new QLBH1Entities())
            {
                empty = qlbh.Products.Where(p => p.ProID == proID).Select(p => p.Quantity).FirstOrDefault() == 0;
            }
            return empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
