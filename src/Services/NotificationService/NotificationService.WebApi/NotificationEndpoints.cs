namespace NotificationService.WebApi;

public static class NotificationEndpoints
{
    public static RouteGroupBuilder MapNotificationEndpoints(this RouteGroupBuilder group)
    {
        group.MapPost("/", (SendNotificationRequest request) =>
        {
            // Delegate to NotificationDispatchService
            return Results.Accepted($"/api/notifications/{Guid.NewGuid()}");
        });

        group.MapGet("/{id:guid}", (Guid id) =>
        {
            return Results.Ok(new { Id = id, IsDelivered = false });
        });

        return group;
    }
}
