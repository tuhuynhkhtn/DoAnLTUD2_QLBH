using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace V1.Ultilities
{
    public class TinhTrangGiaoConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int tinhTrang = (int)value;
            string TinhTrang = null;

            if(tinhTrang == 1)
            {
                TinhTrang = "Đã giao";
            }
            else
            {
                TinhTrang = "Chưa giao";
            }
            return TinhTrang;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
