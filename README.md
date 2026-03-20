# PlatformServices — Topology Test Fixture

> **This is NOT a real application.** It is a synthetic test repository used by
> [StormBoard](https://stormboard.thurley.dev) to verify topology detection in
> Discovery mode.

## Purpose

StormBoard's Discovery mode automatically detects the architectural topology of
a codebase. This repository is designed to be detected as **MonorepoMultiService**
(multiple independently deployable services in a single repository).

## Expected Detection Signals

| Signal | Evidence |
|--------|----------|
| Multiple WebApi entry points | `AuthService.WebApi`, `OrderService.WebApi`, `NotificationService.WebApi` each have `Program.cs` |
| Service-oriented namespaces | `AuthService.Domain.*`, `OrderService.Domain.*`, `NotificationService.Domain.*` |
| Shared common library | `PlatformServices.Common` referenced by all services |
| API gateway | `PlatformServices.Gateway` with YARP-style routing |
| Independent domain models | Each service owns its own domain types with no cross-service domain references |
| Per-service project pairs | Domain + WebApi projects per service (clean architecture per service) |

## Structure

```
src/
  Services/
    AuthService/        — Authentication & authorization
    OrderService/       — Order management
    NotificationService/ — Notification dispatch
  Common/
    PlatformServices.Common/ — Shared abstractions (IRepository, IEventBus)
  Gateway/
    PlatformServices.Gateway/ — API gateway (YARP)
```

## Type Count

~35 types across 8 projects. Intentionally small — just enough structure for
topology detection to identify the MonorepoMultiService pattern.

## License

Public domain. Use freely for testing.
