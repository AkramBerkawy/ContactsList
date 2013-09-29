using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace ContactsTestProject.Convertors
{
    /// <summary>
    /// used to convert from date of birth to boolean when age is less than the specified parameter
    /// or less than twenty if no parameter is set
    /// </summary>
    public class AgeCheckConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var DOB = (DateTime)value;
            var maxAge = parameter == null? 20 : int.Parse(parameter.ToString());
            if (Util.Utility.CalculateAge(DOB) < maxAge)
                return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
