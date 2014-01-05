using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;


namespace Festival.model
{
    class ImgPathToByteConverter : IValueConverter
    {
        public object Convert(object imgpath, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FileStream fs = new FileStream((string)imgpath, FileMode.Open);

            //De foto (het object) is leeg.
            if (fs.Length == 0)
            {
                Console.WriteLine("Fout gelopen bij inladen foto, geen foto gevonden");
                return null;
            } 

            //Lengte van de array instellen.
            byte[] result = new byte[fs.Length];

            fs.Read(result, 0, (int)fs.Length);

            return result;
        }

        //MOET, anders geef IValueConverter errors.
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return "";
            //throw new NotImplementedException();
        }
    }
}
