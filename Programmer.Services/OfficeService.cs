namespace Programmer.Services
{
    using Data;
    using Programmer.Models;
    using Programmer.Services.Dtos.Office;
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

        public UserDto GetUserForHome(string username)
        {
            UserDto userDto = this.context.Users
                .Where(u => u.UserName == username)
                .Select(u => new UserDto
                {
                    Xp = u.Xp,
                    XpForNextLevel = u.XpForNextLevel,
                    Energy = u.Energy,
                    Level = u.Level,
                    Money = u.Money,
                    Bitcoins = u.Bitcoins,
                })
                .FirstOrDefault();

            ProgrammerUser userFromDb = this.context.Users.SingleOrDefault(u => u.UserName == username);

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
