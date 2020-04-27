using Programmer.App.ViewModels.Administration;

namespace Programmer.Services
{
    public interface IAdministrationService
    {
        ManageAccountsViewModel GetAllUserNames(string adminName);

        void MakeUserAdmin(string username);
    }
}
