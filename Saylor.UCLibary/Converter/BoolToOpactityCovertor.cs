using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Saylor.UCLibary.Convertor
{
    public class BoolToOpactityCovertor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            double d = 0;
            try
            {
               bool b  = (bool)value;

               if (b)
               {
                   d = 1;
               }
            }
            catch (Exception)
            {
                
               
            }

            return d;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool result = false;
            try
            {
                double v = (double)value;
                if (v== 0)
                {
                    result = true;
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
    }
}
