
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GameApp
{
    class ResourceController
    {
        public static Uri GetResourceUri(string address)
        {
            return new Uri(address, UriKind.Relative);
        }

        public static BitmapImage GetResourceBitmap(string address)
        {
            return new BitmapImage(GetResourceUri(address));
        }

        public static ImageBrush GetResourceBrush(string address)
        {
            return new ImageBrush(GetResourceBitmap(address));
        }
    }
}
