using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using Net.Codecrete.QrCodeGenerator;
using VCardGenerate.Models;
using VCardGenerate.Services;

namespace VCardGenerate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var result = await client.PostAsJsonAsync("https://api.qr-code-generator.com/v1/create?access-token=0uyHByxRTsv6VlXdVASdylPmMprh2ecqCKlTQmAyB7zAY7QubcKyzF-CE4YcBNl7", new
            {
                frame_name = "no-frame",
                qr_code_text = "BEGIN:VCARD\r\nFN:Chistine d'Aboville\r\nN:d'Aboville;Christine\r\nSORT-STRING:Aboville\r\nEMAIL:zahid@gmail.com\r\nEND:VCARD",
                image_format = "    ",
                qr_code_logo = "scan-me-square"
            });
            ViewBag.Result = await result.Content.ReadAsStringAsync();


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult Index(string qrcode)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var qr = QrCode.EncodeText("Hello, world!", QrCode.Ecc.Medium);
                string svg = qr.ToGraphicsPath(4);
                string path = SaveSvg.SaveSvgString(svg);
                ViewBag.path = path;
                return View();

            }
        }

    }
}
