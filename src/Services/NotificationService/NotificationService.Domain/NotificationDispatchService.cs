using PlatformServices.Common;

namespace NotificationService.Domain;

public class NotificationDispatchService
{
    private readonly IEnumerable<INotificationSender> _senders;
    private readonly IEventBus _eventBus;

    public NotificationDispatchService(IEnumerable<INotificationSender> senders, IEventBus eventBus)
    {
        _senders = senders;
        _eventBus = eventBus;
    }

    public async Task<Result> DispatchAsync(
        Notification notification,
        CancellationToken cancellationToken = default)
    {
        var sender = _senders.FirstOrDefault(s => s.SupportsType(notification.Type));
        if (sender is null)
            return Result.Failure($"No sender available for {notification.Type}");

        var sent = await sender.SendAsync(notification, cancellationToken);
        if (sent)
            notification.MarkDelivered();

        return sent ? Result.Success() : Result.Failure("Send failed");
    }
}
