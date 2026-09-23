using Microsoft.AspNetCore.Mvc;

namespace RoutingApp.Controllers;

public class AdminController : Controller
{
    // Закінчується на "Setup" — дозволено
    public IActionResult InitSetup() => Content("Admin/InitSetup відкрито (закінчується на Setup — дозволено)");

    // Закінчується на "Setup" — дозволено
    public IActionResult UserSetup() => Content("Admin/UserSetup відкрито (закінчується на Setup — дозволено)");

    // Не закінчується на "Setup" — має бути заблоковано
    public IActionResult Dashboard() => Content("Admin/Dashboard відкрито (мало бути заблоковано!)");
}