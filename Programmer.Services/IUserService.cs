namespace Programmer.Services
{
    using System.Threading.Tasks;
    using System;
    using Programmer.App.ViewModels.Users;

    public interface IUserService
    {
        PlayerInfoViewModel GetPlayerInfo(string userId);

        Task<int> UpdateUserEnergy(string userId);

        Task<UpdateUserAfterLectureApiModel> UpgradeUserAfterLecture(string userId);

        DateTime GetTimeNeeded(string userId);
    }
}
