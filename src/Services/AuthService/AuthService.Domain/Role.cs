namespace AuthService.Domain;

public class Role
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public IReadOnlyList<string> Permissions { get; private set; } = [];

    private Role() { }

    public static Role Create(string name, string description, IEnumerable<string> permissions)
    {
        return new Role
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Permissions = permissions.ToList()
        };
    }

    public bool HasPermission(string permission) => Permissions.Contains(permission);
}
