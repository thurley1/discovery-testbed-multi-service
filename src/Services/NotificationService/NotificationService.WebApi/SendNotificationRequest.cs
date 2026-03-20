namespace NotificationService.WebApi;

public sealed record SendNotificationRequest(string Recipient, string Subject, string Body, string Type);
