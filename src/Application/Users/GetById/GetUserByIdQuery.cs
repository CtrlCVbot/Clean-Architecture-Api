using Application.Abstractions.Messaging;

namespace Application.Users.GetById;

public sealed record GetUserByIdQuery(int? Idx) : IQuery<UserResponse>;

