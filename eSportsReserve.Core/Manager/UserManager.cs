using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using eSportsReserve.Core.Data;
using System.Collections.Generic;
using System;


namespace eSportsReserve.Core.Manager
{
    public class UserManager
    {
        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<Avatar> _avatar;
        private readonly DbSet<User> _user;
       

        private readonly ILogger _logger;

        public UserManager(ApplicationDbContext dbContext, ILogger<UserManager> logger)
        {
            _avatar = _dbContext.Set<Avatar>();
            _user = _dbContext.Set<User>();
          

            _logger = logger;
        }

        private IQueryable<Avatar> AvatarInfo()
        {
            return _avatar
              .OrderBy(a => a.UserId);
        }

        private IQueryable<User> UserInfo()
        {
            return _user;
               
        }

        //avatar
        public async Task<IList<Avatar>> GetUserAvatar(Guid userid)
        {
            return await AvatarInfo()
                .Where(a => a.UserId.Equals(userid))
                .ToListAsync();
        }

        public Task CreateAvatar(Avatar avatar)
        {
            _avatar.Add(avatar);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateAvatar(Avatar avatar)
        {
            _avatar.Update(avatar);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAvatar(Avatar avatar)
        {
            _avatar.Remove(avatar);
            return _dbContext.SaveChangesAsync();
        }

        //user

        public async Task<IList<User>> GetUserDetails(Guid userid)
        {
            return await UserInfo()
                .Where(a => a.Id.Equals(userid))
                .ToListAsync();
        }


        public Task CreateUser(User user)
        {
            _user.Add(user);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateUser(User user)
        {
            _user.Update(user);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteUser(User user)
        {
            _user.Remove(user);
            return _dbContext.SaveChangesAsync();
        }


    }
}
