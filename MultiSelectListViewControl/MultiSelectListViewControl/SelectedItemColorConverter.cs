using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MultiSelectListViewControl
{
    public class SelectedItemColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //if (value != null)
            //{
            //    if (parameter != null)
            //    {
            //        if (((MultiSelectListView) parameter).SelectedItems.Any(x => x == value))
            //        {
            //            return Color.Aqua;
            //        }
            //        else
            //        {
            //            return Color.Default;
            //        }
            //    }
            //}

            return Color.Default;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
