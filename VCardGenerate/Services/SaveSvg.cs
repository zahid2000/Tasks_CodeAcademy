using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
namespace VCardGenerate.Services
{
    public static class SaveSvg
    {
        public static string SaveSvgString(string svg)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", Guid.NewGuid()+".svg");
            File.WriteAllText(path, svg, Encoding.UTF8);
            return path;
        }

    }
}
