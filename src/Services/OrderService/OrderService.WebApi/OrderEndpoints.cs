namespace OrderService.WebApi;

public static class OrderEndpoints
{
    public static RouteGroupBuilder MapOrderEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", (CreateOrderRequest request) =>
        {
            // Delegate to OrderManagementService
            return Results.Created($"/api/orders/{Guid.NewGuid()}", new { Id = Guid.NewGuid() });
        });

        group.MapGet("/{id:guid}", (Guid id) =>
        {
            return Results.Ok(new { Id = id, Status = "Draft" });
        });

        group.MapPost("/{id:guid}/submit", (Guid id) =>
        {
            return Results.NoContent();
        });

        return group;
    }
}
