namespace Services.RepositoryInterfaces;

public interface IUnitOfWork : IDisposable
{
    ICityRepository CityRepository { get; }
    IPersonRepository PersonRepository { get; }
    IPersonRelationsRepository PersonRelationsRepository { get; }
    int SaveChanges();
    void BeginTransaction();
    void CommitTransaction();
    void RollBack();
}
