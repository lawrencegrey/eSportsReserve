using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using eSportsReserve.Core.Data;
using System.Collections.Generic;
using System;

namespace eSportsReserve.Core.Manager
{
    public class GroupManager
    {

        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Group> _group;
        private readonly DbSet<PlayerGroup> _playergroup;
        private readonly DbSet<GroupInvitation> _groupinvitation;

        private readonly ILogger _logger;

        public GroupManager(ApplicationDbContext dbContext, ILogger<GroupManager> logger)
        {
            _group = _dbContext.Set<Group>();
            _playergroup = _dbContext.Set<PlayerGroup>();
            _groupinvitation = dbContext.Set<GroupInvitation>();

            _logger = logger;
        }

        private IQueryable<Group> GroupInfo()
        {
            return _group
                .OrderBy(g => g.Name);
        }

        private IQueryable<PlayerGroup> PlayerGroupInfo()
        {
            return _playergroup
                .Include(g => g.Group)
                .Include(p => p.Group.Player)
                .Include(a => a.Group.Player.User.Avatar)                 
                .OrderBy(p => p.Group.Name);           
        }

        private IQueryable<GroupInvitation> GroupInvitationInfo()
        {
            return _groupinvitation
                .Include(g => g.Group)
                //.Include(p => p.Group.Player)
                //.Include(a => a.Group.Player.User.Avatar)
                .OrderBy(p => p.Group.Name);
        }


        //Groups
        public Task CreateGroup(Group group)
        {
            _group.Add(group);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateGroup(Group group)
        {
            _group.Update(group);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteGroup(Group group)
        {
            _group.Remove(group);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Group>> GetGroups()
        {
            return await GroupInfo()                
                .ToListAsync();
        }

        public async Task<IList<Group>> GetGroupByName(string name)
        {
            return await GroupInfo()
                .Where(g => g.Name.Equals(name))
                .ToListAsync();
        }

        public async Task<IList<Group>> GetGroupsIOwn(Guid captainid)
        {
            return await GroupInfo()
                .Where(g => g.CaptainId.Equals(captainid))
                .ToListAsync();
        }


        //Player Group 
        public async Task<IList<PlayerGroup>> GetPlayerGroups(Guid playerid)
        {
            return await PlayerGroupInfo()
                .Where(g => g.PlayerId.Equals(playerid))
                .ToListAsync();
        }

        public async Task<IList<PlayerGroup>> GetPlayersInGroup(Guid groupid)
        {
            return await PlayerGroupInfo()
                .Where(g => g.GroupId.Equals(groupid))
                .ToListAsync();
        }


        public Task CreatePlayerGroup(PlayerGroup playergroup)
        {
            _playergroup.Add(playergroup);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdatePlayerGroup(PlayerGroup playergroup)
        {
            _playergroup.Update(playergroup);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeletePlayerGroup(PlayerGroup playergroup)
        {
            _playergroup.Remove(playergroup);
            return _dbContext.SaveChangesAsync();
        }



        //Group Invitation
        public async Task<IList<GroupInvitation>> GetGroupInvitation(Guid groupid)
        {
            return await GroupInvitationInfo()
                .Where(g => g.GroupId.Equals(groupid))
                .ToListAsync();
        }
        
      
        public Task CreateGroupInvitation(GroupInvitation groupinvitation)
        {
            _groupinvitation.Add(groupinvitation);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateGroupInvitation(GroupInvitation groupinvitation)
        {
            _groupinvitation.Update(groupinvitation);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteGroupInvitation(GroupInvitation groupinvitation)
        {
            _groupinvitation.Remove(groupinvitation);
            return _dbContext.SaveChangesAsync();
        }        

    }
}
