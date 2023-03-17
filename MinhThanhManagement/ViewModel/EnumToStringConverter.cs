using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static MinhThanhManagement.CommonMethod;

namespace MinhThanhManagement.ViewModel
{
    public class EnumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is NoteName)
            {
                switch ((NoteName)value)
                {
                    case NoteName.ToDo:
                        return "Cần Làm";
                    case NoteName.Debt:
                        return "Còn Thiếu";
                    case NoteName.Collect:
                        return "Thu Hóa Đơn";
                }
            }


            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
