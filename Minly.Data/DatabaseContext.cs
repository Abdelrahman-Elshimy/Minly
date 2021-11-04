using Minly.Data.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minly.Data
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<StarCategory> StarCategories { get; set; }
        public DbSet<StarService> StarServices { get; set; }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventMembership> EventMemberships { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventVideo> EventVideos { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<EventRate> EventRates { get; set; }
        public DbSet<StarRate> StarRates { get; set; }
        public DbSet<RequestEvent> RequestEvents { get; set; }
        public DbSet<RequestStar> RequestStars { get; set; }

        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           
            
            builder.ApplyConfiguration(new RoleConfiguration());
        }
    }
}
