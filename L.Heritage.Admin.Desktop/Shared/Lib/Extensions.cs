using System.IO;
using System.Windows.Media.Imaging;

namespace L.Heritage.Admin.Desktop.Shared.Lib;

public static class Extensions
{
    public static BitmapImage FromBase64(this BitmapImage image, string base64)
    {
        string str = base64.Split("base64,")[1];
        image.BeginInit();
        image.StreamSource = new MemoryStream(Convert.FromBase64String(str));
        image.EndInit();
        image.Freeze();
        return image;
    }

    public static string ToBase64(this BitmapImage image)
    {
        using var ms = new MemoryStream();
        var encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(image));
        encoder.Save(ms);
        byte[] bytes = ms.ToArray();
        return "data:image/jpeg;base64," + Convert.ToBase64String(bytes);
    }
}
