using SharedKernel;


public static class CountryErrors
{
    public static Error NotFound(int? Idx) => Error.NotFound(
        "Countries.NotFound",
        $"The Country with the Id = '{Idx}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Countries.Unauthorized",
        "You are not authorized to perform this action.");

    public static readonly Error NotFoundById = Error.NotFound(
        "Countries.NotFoundById",
        "The user with the specified Id was not found");

    public static readonly Error IdNotUnique = Error.Conflict(
        "Countries.IdNotUnique",
        "The provided Id is not unique");
}
