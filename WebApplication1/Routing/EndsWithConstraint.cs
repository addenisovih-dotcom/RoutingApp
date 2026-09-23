using Microsoft.AspNetCore.Routing;

namespace RoutingApp.Routing;

// Дозволяє маршрут тільки якщо значення (наприклад, {action}) закінчується на suffix
public class EndsWithConstraint : IRouteConstraint
{
    private readonly string _suffix;

    public EndsWithConstraint(string suffix)
    {
        _suffix = suffix;
    }

    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
        RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (!values.TryGetValue(routeKey, out var value) || value is null)
        {
            return false;
        }

        var text = value.ToString();
        return text is not null && text.EndsWith(_suffix, StringComparison.OrdinalIgnoreCase);
    }
}