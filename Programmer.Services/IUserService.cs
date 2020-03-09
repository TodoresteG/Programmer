namespace Programmer.Services
{
    using System.Threading.Tasks;
    using System;
    using Programmer.App.ViewModels.Users;

    public interface IUserService
    {
        PlayerInfoViewModel GetPlayerInfo(string userId);

        int UpdateUserEnergy(string userId);

        UpdateUserAfterLectureApiModel UpgradeUserAfterLecture(string userId);

        UpdateUserAfterLectureApiModel UpdateUserAfterExam(string userId);

        DateTime GetTimeNeeded(string userId);
    }
}
