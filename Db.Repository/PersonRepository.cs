using DTOs;
using Microsoft.EntityFrameworkCore;
using Services.RepositoryInterfaces;

namespace Db.Repository;

internal sealed class PersonRepository : RepositoryBase<Person>, IPersonRepository
{
    private new readonly PersonDbContext _context;
    private new readonly DbSet<Person> _dbSet;
    internal PersonRepository(PersonDbContext context) : base(context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<Person>();
    }
    public List<PersonRelations> GetAllRelationships(int id)
    {
        Person person = _dbSet.Find(id) ?? throw new ArgumentNullException(nameof(id));

        var allRelationships = new List<PersonRelations>();

        if (person.FromRelationships != null)
        {
            allRelationships.AddRange(person.FromRelationships);
        }

        if (person.ToRelationships != null)
        {
            allRelationships.AddRange(person.ToRelationships);
        }

        return allRelationships;
    }
}
