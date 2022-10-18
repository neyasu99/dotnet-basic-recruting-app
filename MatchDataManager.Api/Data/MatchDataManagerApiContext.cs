using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MatchDataManager.Api.Models;

namespace MatchDataManager.Api.Data
{
    public class MatchDataManagerApiContext : DbContext
    {
        public MatchDataManagerApiContext (DbContextOptions<MatchDataManagerApiContext> options)
            : base(options)
        {
        }

        public DbSet<MatchDataManager.Api.Models.Location> Location { get; set; } = default!;
        public DbSet<MatchDataManager.Api.Models.Team> Team { get; set; } = default!;
    }
}
