using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using eSportsReserve.Core.Data;
using System.Collections.Generic;
using System;


namespace eSportsReserve.Core.Manager
{
    public class ReservationManager
    {

        private readonly ApplicationDbContext _dbContext;

        private readonly DbSet<Field> _field;
        private readonly DbSet<Reservation> _reservation;
        private readonly DbSet<Availability> _availability;

        private readonly ILogger _logger;

        public ReservationManager(ApplicationDbContext dbContext, ILogger<ReservationManager> logger)
        {
            _field = _dbContext.Set<Field>();
            _reservation = _dbContext.Set<Reservation>();
            _availability = _dbContext.Set<Availability>();

            _logger = logger;
        }

        private IQueryable<Field> FieldInfo()
        {
            return _field            
                .OrderBy(f => f.Name);
        }

        private IQueryable<Reservation> ReservationInfo()
        {
            return _reservation
                .Include(r => r.Group)               
                .Include(r => r.Field)                
                .OrderBy(r => r.GroupId);
        }

        private IQueryable<Availability> AvailabilityInfo()
        {
            return _availability
                .Include(a => a.Reservation)
                .Include(a => a.Player)
                .Include(a => a.Group)
                .Include(a => a.Player.User.Avatar)
                .OrderBy(a => a.PlayerID);
        }


        //Field
        public Task CreateField(Field field)
        {
            _field.Add(field);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateField(Field field)
        {
            _field.Update(field);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteField(Field field)
        {
            _field.Remove(field);
            return _dbContext.SaveChangesAsync();
        }

        public async Task<IList<Field>> GetFields()
        {
            return await FieldInfo()
                .ToListAsync();
        }



        //Reservations

        //group
        public async Task<IList<Reservation>> GetGroupReservations(Guid groupid)
        {
            return await ReservationInfo()
                .Where(r => r.GroupId.Equals(groupid))
                .ToListAsync();
        }

        //player
        public async Task<IList<Reservation>> GetPlayerReservations(Guid playerid)
        {
            return await ReservationInfo()
                .Where(r => r.Group.PlayerGroup.PlayerId.Equals(playerid))
                .ToListAsync();
        }

        //field
        public async Task<IList<Reservation>> GetFieldReservations(Guid fieldid)
        {
            return await ReservationInfo()
                .Where(r => r.FieldId.Equals(fieldid))
                .ToListAsync();
        }


        public Task CreateReservation(Reservation reservation)
        {
            _reservation.Add(reservation);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateReservation(Reservation reservation)
        {
            _reservation.Update(reservation);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteReservation(Reservation reservation)
        {
            _reservation.Remove(reservation);
            return _dbContext.SaveChangesAsync();
        }


        //Availability

        //group
        public async Task<IList<Availability>> GetGroupPlayersAvailabilty(Guid groupid)
        {
            return await AvailabilityInfo()
                .Where(r => r.GroupId.Equals(groupid))
                .ToListAsync();
        }

        //player 
        public async Task<IList<Availability>> GetPlayerAvailablity(Guid playerid)
        {
            return await AvailabilityInfo()
                .Where(r => r.PlayerID.Equals(playerid))
                .ToListAsync();
        }


        public Task CreateAvailability(Availability availability)
        {
            _availability.Add(availability);
            return _dbContext.SaveChangesAsync();
        }

        public Task UpdateAvailability(Availability availability)
        {
            _availability.Update(availability);
            return _dbContext.SaveChangesAsync();
        }

        public Task DeleteAvailability(Availability availability)
        {
            _availability.Remove(availability);
            return _dbContext.SaveChangesAsync();
        }

    }
}
