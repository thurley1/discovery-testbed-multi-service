namespace PlatformServices.Gateway;

public sealed record HealthCheckResponse(
    string Service,
    string Status,
    DateTime CheckedAt,
    int LatencyMs);
