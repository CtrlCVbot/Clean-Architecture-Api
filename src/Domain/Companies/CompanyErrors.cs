using SharedKernel;


public static class CompanyErrors
{
    public static Error NotFound(string? Name) => Error.NotFound(
        "Companies.NotFound",
        $"The Company with the CompanyName = '{Name}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Companies.Unauthorized",
        "You are not authorized to perform this action.");

    public static readonly Error NotFoundById = Error.NotFound(
        "Companies.NotFoundById",
        "The Company with the specified Id was not found");

    public static readonly Error IdNotUnique = Error.Conflict(
        "Companies.IdNotUnique",
        "The provided Id is not unique");
}
