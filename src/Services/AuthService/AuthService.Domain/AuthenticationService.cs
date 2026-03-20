using PlatformServices.Common;

namespace AuthService.Domain;

public class AuthenticationService
{
    private readonly IUserRepository _userRepository;
    private readonly IEventBus _eventBus;

    public AuthenticationService(IUserRepository userRepository, IEventBus eventBus)
    {
        _userRepository = userRepository;
        _eventBus = eventBus;
    }

    public async Task<Result<AuthToken>> AuthenticateAsync(
        string email,
        string passwordHash,
        CancellationToken cancellationToken = default)
    {
        var user = await _userRepository.GetByEmailAsync(email, cancellationToken);
        if (user is null || user.PasswordHash != passwordHash)
            return Result.Failure<AuthToken>("Invalid credentials");

        var token = AuthToken.Issue(user.Id, TimeSpan.FromHours(24));
        return Result.Success(token);
    }
}
