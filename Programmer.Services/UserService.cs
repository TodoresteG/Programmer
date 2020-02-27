namespace Programmer.Services
{
    using Programmer.Data;
    using Programmer.Models;
    using Programmer.Services.Dtos.Users;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserService : IUserService
    {
        private readonly ProgrammerDbContext context;

        public UserService(ProgrammerDbContext context)
        {
            this.context = context;
        }

        public PlayerInfoDto GetPlayerInfo(string userId)
        {
            var user = this.context.Users
                .Where(u => u.Id == userId)
                .Select(u => new PlayerInfoDto
                {
                    Bitcoins = u.Bitcoins,
                    Energy = u.Energy,
                    Level = u.Level,
                    Money = u.Money,
                    TimeRemaining = u.TaskTimeRemaining,
                    Xp = u.Xp,
                    XpForNextLevel = u.XpForNextLevel,
                })
                .FirstOrDefault();

            return user;
        }

        public async Task<int> UpdateUserEnergy(string userId)
        {
            var user = this.context.Users
                .FirstOrDefault(u => u.Id == userId);

            user.Energy++;
            await this.context.SaveChangesAsync();

            return user.Energy;
        }
    }
}
