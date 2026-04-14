using Microsoft.AspNetCore.Mvc;
using SaigonRideProject.Services;

public class PassportController : Controller
{
    private readonly FileUploadService _file;
    private readonly PassportService _passport;

    public PassportController(FileUploadService file, PassportService passport)
    {
        _file = file;
        _passport = passport;
    }

    public IActionResult UploadPassport()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UploadPassport(IFormFile file, string passportNumber)
    {
        try
        {
            Console.WriteLine("UPLOAD START");

            if (file == null || file.Length == 0)
            {
                Console.WriteLine("FILE NULL");
                return View();
            }

            var path = _file.SaveImage(file);

            Console.WriteLine("FILE SAVED: " + path);

            return RedirectToAction("SelectPayment", "Payment");
        }
        catch (Exception ex)
        {
            Console.WriteLine("UPLOAD ERROR: " + ex.ToString());
            return View();
        }
    }
}