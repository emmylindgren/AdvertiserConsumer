using SubscriberAPI.Models;
namespace SubscriberAPI.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }

        public DbSet<SubscriberModel> Subscribers { get; set; }

        public DbSet<AddressModel> Address { get; set; }

        
        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SubscriberModel>()
                .HasOne(e => e.Su_Adress)
                .WithOne(a => a.Subscriber)
                .HasForeignKey<AddressModel>(a => a.Su_Id)
                .OnDelete(DeleteBehavior.ClientCascade);
        }*/

    }
}
