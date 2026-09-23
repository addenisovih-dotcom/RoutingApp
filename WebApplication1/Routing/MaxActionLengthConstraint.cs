using Microsoft.AspNetCore.Routing;

namespace RoutingApp.Routing;

// Дозволяє маршрут тільки якщо довжина значення (наприклад, {action}) не перевищує maxLength
public class MaxActionLengthConstraint : IRouteConstraint
{
    private readonly int _maxLength;

    public MaxActionLengthConstraint(int maxLength)
    {
        _maxLength = maxLength;
    }

    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey,
        RouteValueDictionary values, RouteDirection routeDirection)
    {
        if (!values.TryGetValue(routeKey, out var value) || value is null)
        {
            return false;
        }

        var text = value.ToString();
        return text is not null && text.Length <= _maxLength;
    }
}