using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly JungleDbContext _db;

    public UnitOfWork(JungleDbContext db)
    {
      _db = db;
      // Initialiser chaque repo.passant de DbContext en parametre
      //NomClasse = new NomClasseRepository(_db);

      Travel = new TravelRepository(_db);
      Country = new CountryRepository(_db);
      Destination = new DestinationRepository(_db);
    }

    public ITravelRepository Author => throw new NotImplementedException();

    // Creer une variable de type Interface du Repo. pour chaque repo.
    // INomClasseRepository NomClasse { get; private set; }
    //public IBookRepository Book { get; private set; }

    public ICountryRepository Country { get; private set; }
    public IDestinationRepository Destination { get; private set; }
    public IGuideRepository Guide { get; private set; }
    public ITravelRepository Travel { get; private set; }
    public ITravelRecommendationRepository TravelRecommendation { get; private set; }

    public void Dispose()
    {
      _db.Dispose();
    }

    public void Save()
    {
      _db.SaveChanges();
    }
  }
}
