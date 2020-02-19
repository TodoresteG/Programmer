namespace Programmer.Services
{
    using Dtos.Office;

    public interface IOfficeService
    {
        UserDto GetUserForHome(string username);
    }
}
