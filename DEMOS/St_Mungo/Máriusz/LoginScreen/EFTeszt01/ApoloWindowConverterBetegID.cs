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
    class ApoloWindowConverterBetegID : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MungoSystem ms = new MungoSystem();
            ms.Betegek.Load();
            int betegID = (int)value;
            Betegek beteg = ms.Betegek.Where(b => b.BetegID == betegID && b.Deleted==0).Single();
            People ppl = ms.People.Where(p => p.PeopleID == beteg.PeopleID && p.Deleted == 0).Single();
            string Nev = ppl.Name;
            return Nev;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
