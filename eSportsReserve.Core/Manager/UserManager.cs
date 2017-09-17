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
                .OrderBy(f => f.Name);
        }

        private IQueryable<Reservation> ReservationInfo()
        {
            return _user
                .OrderBy(r => r.GroupId);
        }

       

    }
}
