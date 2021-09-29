using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SimpleQuizCreator.Converters
{
    public class ScoreTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string strEnum;

            try
            {
                strEnum = Enum.GetName((value.GetType()), value);
                return strEnum;
            }
            catch (Exception)
            {
                return string.Empty;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
