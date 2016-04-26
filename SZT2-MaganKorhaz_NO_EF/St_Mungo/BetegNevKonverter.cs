using St_Mungo.StMungo_WCF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EFTeszt01
{
    class BetegNevKonverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            StMungoServiceClient smc = new StMungoServiceClient();
            ObservableCollection<People> betegek= value as ObservableCollection<People>;
            ObservableCollection<string> betegekNevei = new ObservableCollection<string>();
            foreach (var b in betegek) {
                betegekNevei.Add(b.UserName);
            }
            return betegekNevei;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
