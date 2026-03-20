var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGroup("/api/notifications").MapNotificationEndpoints();

app.Run();

public partial class Program { }
