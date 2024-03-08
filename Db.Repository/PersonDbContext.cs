using DTOs;
using Microsoft.EntityFrameworkCore;

namespace Db.Repository;

public class PersonDbContext : DbContext
{
    public PersonDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Person>()
           .HasOne(p => p.City)
           .WithMany(c => c.People)
           .HasForeignKey(p => p.CityId);

        modelBuilder.Entity<PersonRelations>()
            .HasOne(r => r.FromPerson)
            .WithMany(p => p.Relationships)
            .HasForeignKey(r => r.FromId);

        modelBuilder.Entity<PersonRelations>()
            .HasOne(r => r.ToPerson)
            .WithMany(p => p.Relationships)
            .HasForeignKey(r => r.ToId);
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<PersonRelations> PersonRelations { get; set; }
}
