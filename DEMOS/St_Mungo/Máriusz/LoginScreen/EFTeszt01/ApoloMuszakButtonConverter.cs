using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EFTeszt01
{
    class ApoloMuszakButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int peopleID = (int)value;
            MungoSystem ms = new MungoSystem();
            int y= DateTime.Now.Year;
            int m= DateTime.Now.Month;
            int d = DateTime.Now.Day;
            DateTime ma = new DateTime(y, m, d);
            ms.ApoloMuszak.Load();
            if (ms.ApoloMuszak.Where(am => am.Datum==ma
                    && am.PeopleID==peopleID && am.Deleted==0).Count()>1)
            {
                return "Műszak leadása";
            }
            else
            {
                return "Műszak leadása";
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
