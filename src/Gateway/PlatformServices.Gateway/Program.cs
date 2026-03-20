// API Gateway — routes requests to downstream services
// In production, this would use YARP (Yet Another Reverse Proxy)
// Routes:
//   /api/auth/*          → AuthService         (localhost:5001)
//   /api/orders/*        → OrderService         (localhost:5002)
//   /api/notifications/* → NotificationService  (localhost:5003)

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddReverseProxy()
//     .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<PlatformServices.Gateway.GatewayConfig>();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new { Status = "Healthy" }));

// app.MapReverseProxy();

app.Run();

public partial class Program { }
