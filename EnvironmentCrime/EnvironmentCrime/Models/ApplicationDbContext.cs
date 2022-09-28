using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnvironmentCrime.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Department> departments { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Errand> errands { get; set; }
        public DbSet<ErrandStatus> errandStatuses { get; set; }
        public DbSet<Picture> pictures { get; set; }
        public DbSet<Sequence> sequences { get; set; }
    }
}
