using St_Mungo.StMungo_WCF;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EFTeszt01
{
    class ApoloWindowLazlapListboxisEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StMungoServiceClient smc = new StMungoServiceClient();
            int peopleID = (int)value;
            smc.ApoloMuszak_getLoad();
            return (smc.mungoSystem().ApoloMuszak.Where(am => am.EndDate == null
                    && am.PeopleID == peopleID && am.Deleted == 0).Count() > 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
