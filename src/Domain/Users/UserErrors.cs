using SharedKernel;


public static class UserErrors
{
    public static Error NotFound(int? Idx) => Error.NotFound(
        "Users.NotFound",
        $"The user with the Id = '{Idx}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Users.Unauthorized",
        "You are not authorized to perform this action.");

    public static readonly Error NotFoundById = Error.NotFound(
        "Users.NotFoundById",
        "The user with the specified Id was not found");

    public static readonly Error IdNotUnique = Error.Conflict(
        "Users.IdNotUnique",
        "The provided Id is not unique");
}
