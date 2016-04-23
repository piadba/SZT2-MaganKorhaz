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
    class ApoloWindowOrvosID : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MungoSystem ms = new MungoSystem();
            ms.People.Load();
            int orvosID = (int)value;
            People ppl = ms.People.Where(p => p.PeopleID == orvosID && p.Deleted == 0).Single();
            string Nev = ppl.Name;
            return Nev;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
