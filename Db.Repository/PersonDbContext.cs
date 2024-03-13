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
              .HasKey(pr => new { pr.FromId, pr.ToId });

        modelBuilder.Entity<PersonRelations>()
            .HasOne(pr => pr.FromPerson)
            .WithMany(p => p.FromRelationships)
            .HasForeignKey(pr => pr.FromId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PersonRelations>()
            .HasOne(pr => pr.ToPerson)
            .WithMany(p => p.ToRelationships)
            .HasForeignKey(pr => pr.ToId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<PersonRelations> PersonRelations { get; set; }
}
