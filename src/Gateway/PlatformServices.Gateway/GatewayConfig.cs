namespace PlatformServices.Gateway;

public class GatewayConfig
{
    public string AuthServiceUrl { get; set; } = "http://localhost:5001";
    public string OrderServiceUrl { get; set; } = "http://localhost:5002";
    public string NotificationServiceUrl { get; set; } = "http://localhost:5003";
    public int RequestTimeoutSeconds { get; set; } = 30;
    public bool EnableCors { get; set; } = true;

    public Dictionary<string, string> GetRouteMap() => new()
    {
        ["/api/auth"] = AuthServiceUrl,
        ["/api/orders"] = OrderServiceUrl,
        ["/api/notifications"] = NotificationServiceUrl
    };
}
