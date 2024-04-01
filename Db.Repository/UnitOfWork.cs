using Services.RepositoryInterfaces;

namespace Db.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonDbContext _context;
        private readonly Lazy<ICityRepository> _cityRepository;
        private readonly Lazy<IPersonRepository> _personRepository;
        private readonly Lazy<IPersonRelationsRepository> _personRelationsRepository;

        public UnitOfWork(PersonDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _cityRepository = new Lazy<ICityRepository>(() => new CityRepository(context));
            _personRepository = new Lazy<IPersonRepository>(() => new PersonRepository(context));
            _personRelationsRepository = new Lazy<IPersonRelationsRepository>(() => new PersonRelationsRepository(context));
        }

        public ICityRepository CityRepository => _cityRepository.Value;

        public IPersonRepository PersonRepository => _personRepository.Value;

        public IPersonRelationsRepository PersonRelationsRepository => _personRelationsRepository.Value;

        public int SaveChanges() => _context.SaveChanges();

        public void BeginTransaction()
        {
            if (_context.Database.CurrentTransaction != null)
            {
                throw new InvalidOperationException("A Transaction is already in progress.");
            }

            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
                _context.Database.CurrentTransaction?.Commit();
            }
            catch
            {
                _context.Database.CurrentTransaction?.Rollback();
                throw;
            }
            finally
            {
                _context.Database.CurrentTransaction?.Dispose();
            }
        }

        public void RollBack()
        {
            try
            {
                _context.Database.CurrentTransaction?.Rollback();
            }
            finally
            {
                _context.Database.CurrentTransaction?.Dispose();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
