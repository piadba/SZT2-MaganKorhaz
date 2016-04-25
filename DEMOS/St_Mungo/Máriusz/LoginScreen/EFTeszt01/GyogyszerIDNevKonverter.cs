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
    class GyogyszerIDNevKonverter : IValueConverter
    {
        OrvosViewModel ovm = OrvosViewModel.Get();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {           
            ObservableCollection<KiadottGyogyszer> kgy = value as ObservableCollection<KiadottGyogyszer>;
            ObservableCollection<string> nevek = new ObservableCollection<string>();
            foreach (var item in kgy)
            {
                nevek.Add(ovm.GyogyszerNev(int.Parse(item.GyogyszerID.ToString())) + "\tMennyiség: " + item.Mennyiseg);
            }
            return nevek;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
