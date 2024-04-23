using DTOs;
using Microsoft.EntityFrameworkCore;
using Services.RepositoryInterfaces;
using System;

namespace Db.Repository;

internal sealed class PersonRepository : RepositoryBase<Person>, IPersonRepository
{

    internal PersonRepository(PersonDbContext context) : base(context)
    {

    }
    internal async Task<List<Person>> GetPersonRelationships(int personId)
    {
               return await (from p in _context.People
                            join r in _context.PersonRelations on p.Id equals r.FromId into PersonRelations
                            from pr in PersonRelations.DefaultIfEmpty()
                            where (pr.FromId == personId || pr.ToId == personId) && p.Id != personId
                            select p).ToListAsync();
    }
}
