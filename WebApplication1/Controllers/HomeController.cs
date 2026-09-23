using Microsoft.AspNetCore.Mvc;

namespace RoutingApp.Controllers;

public class HomeController : Controller
{
    // Index — 5 символів, дозволено
    public IActionResult Index() => View();

    // About — 5 символів, дозволено
    public IActionResult About() => Content("Home/About відкрито (5 символів — дозволено)");

    // Contact — 7 символів, має бути заблоковано маршрутизацією
    public IActionResult Contact() => Content("Home/Contact відкрито (7 символів — мало бути заблоковано!)");

    // Feedback — 8 символів, має бути заблоковано
    public IActionResult Feedback() => Content("Home/Feedback відкрито (8 символів — мало бути заблоковано!)");
}