using SharedKernel;


public static class PortErrors
{
    public static Error NotFound(int? Idx) => Error.NotFound(
        "Ports.NotFound",
        $"The port with the Id = '{Idx}' was not found");

    public static Error Unauthorized() => Error.Failure(
        "Ports.Unauthorized",
        "You are not authorized to perform this action.");

    public static readonly Error NotFoundById = Error.NotFound(
        "Ports.NotFoundById",
        "The port with the specified Id was not found");

    public static readonly Error IdNotUnique = Error.Conflict(
        "Ports.IdNotUnique",
        "The provided Id is not unique");
}
