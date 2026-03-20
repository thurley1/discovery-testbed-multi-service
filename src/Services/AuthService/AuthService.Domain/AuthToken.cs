namespace AuthService.Domain;

public class AuthToken
{
    public Guid Id { get; private set; }
    public Guid UserId { get; private set; }
    public string Token { get; private set; } = string.Empty;
    public DateTime ExpiresAt { get; private set; }
    public bool IsRevoked { get; private set; }

    private AuthToken() { }

    public static AuthToken Issue(Guid userId, TimeSpan lifetime)
    {
        return new AuthToken
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray()),
            ExpiresAt = DateTime.UtcNow.Add(lifetime),
            IsRevoked = false
        };
    }

    public bool IsExpired() => DateTime.UtcNow >= ExpiresAt;
    public void Revoke() => IsRevoked = true;
}
