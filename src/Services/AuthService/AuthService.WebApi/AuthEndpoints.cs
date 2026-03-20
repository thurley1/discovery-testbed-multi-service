namespace AuthService.WebApi;

public static class AuthEndpoints
{
    public static RouteGroupBuilder MapAuthEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/login", (LoginRequest request) =>
        {
            // Delegate to AuthenticationService
            return Results.Ok(new { Token = "stub" });
        });

        group.MapPost("/logout", () =>
        {
            return Results.NoContent();
        });

        group.MapGet("/me", () =>
        {
            return Results.Ok(new { Email = "stub@example.com" });
        });

        return group;
    }
}
