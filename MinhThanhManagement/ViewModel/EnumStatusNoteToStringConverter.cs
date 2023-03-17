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
    public class EnumStatusNoteToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is noteEnum)
            {
                switch ((noteEnum)value)
                {
                    case noteEnum.Done:
                        return "Hoàn Thành";
                    case noteEnum.NotDone:
                        return "Đang Làm";
                }
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return value;
            throw new NotImplementedException();
        }
    }
}
