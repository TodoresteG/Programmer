namespace Programmer.Services
{
    using System.Threading.Tasks;
    using System;
    using Programmer.App.ViewModels.Users;

    public interface IUserService
    {
        PlayerInfoViewModel GetPlayerInfo(string userId);

        int UpdateUserEnergy(string userId);

        UpdateUserAfterActivityApiModel UpdateUserAfterLecture(string userId);

        UpdateUserAfterActivityApiModel UpdateUserAfterExam(string userId);

        UpdateUserAfterActivityApiModel UpdateUserAfterDocumentation(string userId);

        DateTime GetTimeNeeded(string userId);
    }
}
