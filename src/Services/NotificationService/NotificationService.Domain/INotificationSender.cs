namespace NotificationService.Domain;

public interface INotificationSender
{
    Task<bool> SendAsync(Notification notification, CancellationToken cancellationToken = default);
    bool SupportsType(NotificationType type);
}
