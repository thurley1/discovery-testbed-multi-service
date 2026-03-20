var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGroup("/api/auth").MapAuthEndpoints();

app.Run();

public partial class Program { }
