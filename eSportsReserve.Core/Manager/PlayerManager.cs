using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using eSportsReserve.Core.Data;

namespace eSportsReserve.Core.Manager
{
    public class PlayerManager
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Player> _player;

        private readonly ILogger _logger;

        public PlayerManager(ApplicationDbContext dbContext, ILogger<PlayerManager> logger)
        {
            _player = _dbContext.Set<Player>();
            _logger = logger;
        }

        private IQueryable<Player> PlayerInfo()
        {
            return _player
                .Include(p => p.User)
                .Include(p => p.User.Avatar)
                .OrderBy(p => p.LastName);
        }

        public async Task<IList<Player>> GetPlayers()
        {
            return await PlayerInfo()
                .ToListAsync();
        }


        public async Task<IList<Player>> GetPlayerByContactNo(string contactno)
        {
            return await PlayerInfo()
                .Where(p => p.ContactNo.Equals(contactno))
                .ToListAsync();
        }

        public async Task<IList<Player>> GetPlayerByName(string name)
        {
            return await PlayerInfo()
                .Where(p => p.FirstName.Contains(name)  || p.LastName.Contains(name))
                .ToListAsync();
        }


        //Player
        public Task CreatePlayer(Player player)
        {
            _player.Add(player);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdatePlayer(Player player)
        {
            _player.Update(player);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeletePlayer(Player player)
        {
            _player.Remove(player);
            return _dbContext.SaveChangesAsync();
        }

    }
}
