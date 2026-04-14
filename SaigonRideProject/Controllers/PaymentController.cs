using Microsoft.AspNetCore.Mvc;

public class PaymentController : Controller
{
    public IActionResult SelectPayment()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Pay(string method, decimal amount)
    {
        ViewBag.Result = $"Paid {amount} via {method}";
        return View();
    }
}