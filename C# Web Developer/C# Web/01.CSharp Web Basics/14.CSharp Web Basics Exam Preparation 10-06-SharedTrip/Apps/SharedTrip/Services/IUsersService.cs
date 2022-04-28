namespace SharedTrip.Services
{
    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void Create(string username, string email, string password);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);
    }
}