using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SportsDash.ViewModel
{
    public class RadioButtonToBool:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && parameter is string)
            {
                bool booleanValue = (bool)value;
                string parameterValue = (string)parameter;
                if (booleanValue)
                {
                    return parameterValue == "True";
                }
                else
                {
                    return parameterValue == "False";
                }
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool && parameter is string)
            {
                bool booleanValue = (bool)value;
                string parameterValue = (string)parameter;
                if (booleanValue)
                {
                    return parameterValue == "True";
                }
                else
                {
                    return parameterValue == "False";
                }
            }
            return false;
        }
    }
}
