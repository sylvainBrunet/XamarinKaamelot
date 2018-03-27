using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace SBR.Converters
{
    public class StringToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var assembly = typeof(App).Assembly;
            
            var resource = value.ToString();
            
            
            if(assembly.GetManifestResourceNames().Where(x => x == "SBR.Ressources.Images." +resource+".png").Count() > 0)
            {
                return ImageSource.FromResource("SBR.Ressources.Images." +resource+".png");

            }
            else
            {
                return ImageSource.FromResource("SBR.Ressources.Images.profile_generic.png");
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
