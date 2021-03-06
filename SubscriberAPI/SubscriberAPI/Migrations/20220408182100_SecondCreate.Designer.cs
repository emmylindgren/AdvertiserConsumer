// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubscriberAPI.Data;

#nullable disable

namespace SubscriberAPI.Migrations
{
    [DbContext(typeof(Database))]
    [Migration("20220408182100_SecondCreate")]
    partial class SecondCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SubscriberAPI.Models.SubscriberModel", b =>
                {
                    b.Property<int>("Su_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Su_Id"), 1L, 1);

                    b.Property<string>("Su_City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Su_FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Su_LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Su_PersonId")
                        .HasColumnType("bigint");

                    b.Property<int>("Su_PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("Su_Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Su_Id");

                    b.ToTable("Tbl_Subscribers");
                });
#pragma warning restore 612, 618
        }
    }
}
