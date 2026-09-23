using Microsoft.AspNetCore.Mvc;

namespace RoutingApp.Controllers;

public class ShopController : Controller
{
    public IActionResult Buy() =>
        Content("Shop/Buy викликано (через /newOrder або /Shop/Buy)");

    public IActionResult Index() => Content("Shop/Index");
}