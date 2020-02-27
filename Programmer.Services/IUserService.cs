namespace Programmer.Services
{
    using Programmer.Services.Dtos.Users;
    using System.Threading.Tasks;

    public interface IUserService
    {
        PlayerInfoDto GetPlayerInfo(string userId);

        Task<int> UpdateUserEnergy(string userId);
    }
}
