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
    class KezelesKonverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            OrvosViewModel ovm = OrvosViewModel.Get();
            ObservableCollection<Kortortenet_tetel> kt = value as ObservableCollection<Kortortenet_tetel>;
            if (kt != null)
            {
                ObservableCollection<string> s = new ObservableCollection<string>();
                foreach (var e in kt)
                {
                    s.Add("Dátum: " + e.Datum + "\tOrvos: " + ovm.OrvosID2Name((int)e.Orvos) + "\tKezelés: " + e.Kezeles);
                }
                return s;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
