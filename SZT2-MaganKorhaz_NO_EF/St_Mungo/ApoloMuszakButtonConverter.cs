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
    class ApoloMuszakButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int peopleID = (int)value;
            StMungoServiceClient smc = new StMungoServiceClient();
            MungoSystem ms = new MungoSystem();
            smc.ApoloMuszak_getLoad();
            if (ms.ApoloMuszak.Where(am => am.EndDate==null
                    && am.PeopleID==peopleID && am.Deleted==0).Count()>0)
            {
                return "Műszak leadása";
            }
            else
            {
                return "Műszak felvétele";
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
