namespace packages.Api.Responses.Enums
{
    public enum ErrorCode
    {
        Unexpected,
        RequestParameterNull,
        InvalidAuthenticationCredentials,
        UnauthorizedUser,
        MissingConfiguration,
        EmptyResponse,
        InsertAlreadyExists,
        EntityNotFound
    }
}
