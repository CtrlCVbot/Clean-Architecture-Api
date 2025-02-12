namespace Application.Users.GetById;

public sealed record UserResponse
{
    public int? Idx { get; init; }
    public string? CorpName { get; init; }
    public string? UserTeam { get; init; }
    public string? UserName { get; init; }
    public string? UserHP { get; init; }
}
