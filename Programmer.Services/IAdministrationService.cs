using Programmer.App.ViewModels.Administration;

namespace Programmer.Services
{
    public interface IAdministrationService
    {
        ManageAccountsViewModel GetAllUserNames();

        void MakeUserAdmin(string username);
    }
}
