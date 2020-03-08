namespace Programmer.Services
{
    using Data;
    using Programmer.App.ViewModels.Office;
    using Programmer.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class OfficeService : IOfficeService
    {
        private readonly ProgrammerDbContext context;

        public OfficeService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public OfficeViewModel GetUserForHome(string userId)
        {
            var userDto = new OfficeViewModel();

            ProgrammerUser userFromDb = this.context.Users.SingleOrDefault(u => u.Id == userId);

            var userStats = new Dictionary<string, double?>();

            foreach (PropertyInfo property in typeof(ProgrammerUser).GetProperties())
            {
                var propValue = property.GetValue(userFromDb);

                if ((propValue != null && property.PropertyType == typeof(double)) || (propValue == null && property.PropertyType == typeof(double?)))
                {
                    userStats.Add(property.Name, (double?)propValue);
                }
            }

            userDto.UserStats = userStats;

            return userDto;
        }
    }
}
