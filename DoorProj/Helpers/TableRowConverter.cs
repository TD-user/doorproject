using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using Entities;

namespace DoorProj.Helpers
{
    public class TableRowConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                Status status = (Status)value;
                SolidColorBrush color = new SolidColorBrush(Colors.White);
                switch (status)
                {
                    case Status.Done:
                        color = new SolidColorBrush(Color.FromArgb(200, 51, 204, 0));
                        break;
                    case Status.Fail:
                        color = new SolidColorBrush(Color.FromArgb(200, 255, 51, 51));
                        break;
                    case Status.InProcess:
                        color = new SolidColorBrush(Color.FromArgb(200, 255, 255, 102));
                        break;
                }
                return color;
            }
            catch
            {
                return new SolidColorBrush(Colors.White);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
