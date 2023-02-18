using Microsoft.EntityFrameworkCore;
using ST = Student.Entity.Services.Models.Entity;

namespace Student.DataAccess.Services.Contexts
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> dbContextOptions) : base(dbContextOptions)
        {

        }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Initial Catalog=StudentDemo; TrustServerCertificate=True; Trusted_Connection=True;");
            }
        }

        public DbSet<ST::Student> Students { get; set; }
    }
}
