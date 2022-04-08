using SubscriberAPI.Models;
namespace SubscriberAPI.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }

        public DbSet<SubscriberModel> Subscribers { get; set; }

       
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SubscriberModel>()
                .HasOne(e => e.Su_Adress)
                .WithOne(i => i.)
                .OnDelete(DeleteBehavior.ClientCascade);
        }*/

    }
}
