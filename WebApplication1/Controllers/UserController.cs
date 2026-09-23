using Microsoft.AspNetCore.Mvc;

namespace RoutingApp.Controllers;

public class UserController : Controller
{
    // Нова адреса: /user/settings/{id}, id від 1 до 999
    public IActionResult Settings(int id) =>
        Content($"User/Settings — налаштування користувача з id = {id} (нова адреса)");

    // Стара адреса: /usersettings/{id} — робить редірект на нову
    public IActionResult RedirectOldSettings(int id) =>
        RedirectPermanent($"/user/settings/{id}");
}