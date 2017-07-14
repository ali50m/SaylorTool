using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Saylor.UCLibary.Convertor
{
    public class ReverseVisibilityCovertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility v =  Visibility.Collapsed;
            try
            {
                Visibility b = (Visibility)value;

                if (b == Visibility.Visible)
                {
                    v = Visibility.Collapsed;
                }
                else
                {
                    v = Visibility.Visible;
                }
            }
            catch (Exception)
            {
                v = Visibility.Collapsed;
            }

            return v;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
