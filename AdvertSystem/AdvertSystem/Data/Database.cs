using AdvertSystem.Models;
namespace AdvertSystem.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }

        public DbSet<AdModel> Ads { get; set; }

        public DbSet<AnnonsorerModel> Annonsorer { get; set; }

        public DbSet<CompanyModel> Companies { get; set; }


    }
}
