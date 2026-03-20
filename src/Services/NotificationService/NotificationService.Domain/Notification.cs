namespace NotificationService.Domain;

public class Notification
{
    public Guid Id { get; private set; }
    public string Recipient { get; private set; } = string.Empty;
    public string Subject { get; private set; } = string.Empty;
    public string Body { get; private set; } = string.Empty;
    public NotificationType Type { get; private set; }
    public DateTime SentAt { get; private set; }
    public bool IsDelivered { get; private set; }

    private Notification() { }

    public static Notification Create(string recipient, string subject, string body, NotificationType type)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(recipient);

        return new Notification
        {
            Id = Guid.NewGuid(),
            Recipient = recipient,
            Subject = subject,
            Body = body,
            Type = type,
            SentAt = DateTime.UtcNow,
            IsDelivered = false
        };
    }

    public void MarkDelivered() => IsDelivered = true;
}
