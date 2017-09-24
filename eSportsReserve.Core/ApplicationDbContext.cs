using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using eSportsReserve.Core.Data;

namespace eSportsReserve.Core
{
    public class ApplicationDbContext  : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        //Core
        public virtual DbSet<Availability> Availability { get; set; }
        public virtual DbSet<Field> Field { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<Player> Player { get; set; }
        public virtual DbSet<PlayerGroup> PlayerGroup { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<Data.Guid> User  { get; set; }
        
    }
}
