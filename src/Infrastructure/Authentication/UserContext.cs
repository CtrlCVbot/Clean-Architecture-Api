using Application.Abstractions.Authentication;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Authentication;

internal sealed class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int Idx =>
        _httpContextAccessor
            .HttpContext?
            .User
            .GetUserIdx() ??
        throw new ApplicationException("User context is unavailable");
    
}
