namespace AngularInterceptor.API
{
    public interface IJWTAuthenticationManager
    {
        string? Authenticate(string username, string password);
    }
}
