using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Paradise.Models;
using Paradise.Models.FormModels;

namespace Paradise.Data
{
    public class AppDbContext : IdentityDbContext<SuperUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) { }
        public DbSet<SuperUser> SuperUsers { get; set; }
        public DbSet<ACA> ACA { get; set; }
        public DbSet<AutoInsurance> AutoInsurance { get; set; }
        public DbSet<MVA> MVA { get; set; }
        public DbSet<FinalInsurance> FinalInsurance { get; set; }
        public DbSet<Medicare> Medicare { get; set; }
        public DbSet<ContactUs> Contacts { get; set; }
    }
}
