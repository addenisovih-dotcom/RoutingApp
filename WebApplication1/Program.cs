using RoutingApp.Routing;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

// 1. /newOrder → Shop.Buy
app.MapControllerRoute(
    name: "buy",
    pattern: "newOrder",
    defaults: new { controller = "Shop", action = "Buy" });

// 3a. Стара адреса /usersettings/{id} (1-999) → редірект на нову
app.MapControllerRoute(
    name: "old-user-settings",
    pattern: "usersettings/{id:range(1,999)}",
    defaults: new { controller = "User", action = "RedirectOldSettings" });

// 3b. Нова адреса /user/settings/{id} (1-999)
app.MapControllerRoute(
    name: "user-settings",
    pattern: "user/settings/{id:range(1,999)}",
    defaults: new { controller = "User", action = "Settings" });

// 2. Home — доступні лише дії з довжиною імені ≤ 6 символів
app.MapControllerRoute(
    name: "home",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    constraints: new
    {
        controller = "^Home$",
        action = new MaxActionLengthConstraint(6)
    });

// 4. Admin — доступні лише дії, назва яких закінчується на "setup"
app.MapControllerRoute(
    name: "admin",
    pattern: "{controller=Admin}/{action}/{id?}",
    constraints: new
    {
        controller = "^Admin$",
        action = new EndsWithConstraint("setup")
    });

// Загальний маршрут для решти контролерів (Shop, User тощо) — без обмежень
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}",
    constraints: new
    {
        controller = "^(?!Home$|Admin$).*$"
    });

app.Run();