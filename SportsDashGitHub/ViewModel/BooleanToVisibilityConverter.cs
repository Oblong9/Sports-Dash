using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace SportsDash.ViewModel
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool boolValue = (bool)value;
            bool invert = (parameter as string)?.ToLower() == "invert";

            if (invert)
            {
                return boolValue ? Visibility.Collapsed : Visibility.Visible;
            }
            else
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility visibilityValue = (Visibility)value;
            bool invert = (parameter as string)?.ToLower() == "invert";

            if (invert)
            {
                return visibilityValue == Visibility.Collapsed || visibilityValue == Visibility.Hidden;
            }
            else
            {
                return visibilityValue == Visibility.Visible;
            }
        }
    }
}

