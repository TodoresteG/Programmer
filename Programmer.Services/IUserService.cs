namespace Programmer.Services
{
    using Programmer.Services.Dtos.Users;
    using System.Threading.Tasks;

    public interface IUserService
    {
        UserInfoDto GetPlayerInfo(string userId);

        Task<int> UpdateUserEnergy(string userId);

        Task<UpdateUserAfterLectureDto> UpgradeUserAfterLecture(string userId);
    }
}
