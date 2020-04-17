namespace Programmer.Services
{
    using Data;
    using Programmer.App.ViewModels.Office;
    using Programmer.Services.Dtos;
    using Programmer.Services.Mapping;
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
            var userFromDb = this.context.Users
                .Where(u => u.Id == userId)
                .To<UserStatsViewModel>()
                .FirstOrDefault();

            var userStats = new Dictionary<string, double?>();
            var gainedStats = typeof(UserStatsViewModel).GetProperties()
                .Where(p => p.PropertyType == typeof(double) || p.PropertyType == typeof(double?));

            foreach (PropertyInfo property in gainedStats)
            {
                var propValue = property.GetValue(userFromDb);

                if (propValue != null)
                {
                    userStats.Add(property.Name, (double?)propValue);
                }
            }

            userDto.UserStats = userStats;
            return userDto;
        }
    }
}
