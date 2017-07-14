using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Saylor.UCLibary.Convertor
{
    public class CountToVisibilityCovertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility v =  Visibility.Collapsed;
            try
            {
                int i = (int)value;

               if (i>1)
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
            int result = 0;
            try
            {
                Visibility v = (Visibility)value;
                if (v== Visibility.Visible)
                {
                    result = 2;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
