using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ImdbProject.Converters
{
    public class StringFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string text || string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }
            var formatString = text.Replace("_", " ").Replace(",", ", ");
            var testInfo = culture.TextInfo;
            return testInfo.ToTitleCase(formatString.ToLower());
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not string text || string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }
            var formatString = text.Replace(" ", "_").Replace(", ", ",");
            var testInfo = culture.TextInfo;
            return testInfo.ToLower(formatString);
        }
    }
}
