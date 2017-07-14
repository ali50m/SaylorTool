using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Saylor.UCLibary.Convertor
{
    public class BoolReverseToVisibilityCovertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility v =  Visibility.Collapsed;
            try
            {
               bool b  = (bool)value;

               if (!b)
               {
                   v = Visibility.Visible;
               }
            }
            catch (Exception)
            {
                
               
            }

            return v;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = true;
            try
            {
                Visibility v = (Visibility)value;
                if (v== Visibility.Visible)
                {
                    result = false;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
