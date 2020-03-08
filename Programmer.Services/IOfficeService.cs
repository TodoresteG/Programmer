namespace Programmer.Services
{
    using Programmer.App.ViewModels.Office;

    public interface IOfficeService
    {
        OfficeViewModel GetUserForHome(string userId);
    }
}
