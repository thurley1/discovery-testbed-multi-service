namespace NotificationService.Domain;

public class NotificationTemplate
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string SubjectTemplate { get; private set; } = string.Empty;
    public string BodyTemplate { get; private set; } = string.Empty;
    public NotificationType Channel { get; private set; }

    private NotificationTemplate() { }

    public static NotificationTemplate Create(string name, string subjectTemplate, string bodyTemplate, NotificationType channel)
    {
        return new NotificationTemplate
        {
            Id = Guid.NewGuid(),
            Name = name,
            SubjectTemplate = subjectTemplate,
            BodyTemplate = bodyTemplate,
            Channel = channel
        };
    }

    public string RenderSubject(Dictionary<string, string> variables)
    {
        var result = SubjectTemplate;
        foreach (var (key, value) in variables)
            result = result.Replace($"{{{{{key}}}}}", value);
        return result;
    }

    public string RenderBody(Dictionary<string, string> variables)
    {
        var result = BodyTemplate;
        foreach (var (key, value) in variables)
            result = result.Replace($"{{{{{key}}}}}", value);
        return result;
    }
}
