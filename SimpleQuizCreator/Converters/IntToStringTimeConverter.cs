using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SimpleQuizCreator.Converters
{
    public class IntToStringTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if( !string.IsNullOrEmpty(value.ToString()))
            {
                TimeSpan time = TimeSpan.FromSeconds(int.Parse(value.ToString()));
                return time.ToString(@"hh\:mm\:ss");
            }
            return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
