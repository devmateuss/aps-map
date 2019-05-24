
using Aps.Domain;
using Microsoft.EntityFrameworkCore;

namespace Aps.Repository
{
    public class ApsContext : DbContext
    {
        public ApsContext(DbContextOptions<ApsContext> options) : base (options){}
        public DbSet<Student> Students { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}