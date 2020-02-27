namespace Programmer.Services
{
    using Programmer.Services.Dtos.Users;

    public interface IUserService
    {
        void UpdateUser(string userId);

        PlayerInfoDto GetPlayerInfo(string userId);
    }
}
