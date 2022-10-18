using MatchDataManager.Api.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MatchDataManager.Api.DAL
{
    public class MatchDataContext : DbContext
    {
        public MatchDataContext() : base("MatchDataContext")
        {
        }

        public DbSet<Location> Location { get; set; }
        public DbSet<Team> Team { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
