using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SacramentMeetingPlanner.Models
{
    public class SacramentMeetingPlannerContext : DbContext
    {
        public SacramentMeetingPlannerContext (DbContextOptions<SacramentMeetingPlannerContext> options)
            : base(options)
        {
        }

        public DbSet<SacramentMeetingPlanner.Models.SMP> SMP { get; set; }
        public DbSet<SacramentMeetingPlanner.Models.Member> Member { get; set; }
        public DbSet<SacramentMeetingPlanner.Models.Hymn> Hymn { get; set; }
        public DbSet<SacramentMeetingPlanner.Models.Ward> Ward { get; set; }
        public DbSet<SacramentMeetingPlanner.Models.Speakers> Speakers { get; set; }

    }
}
