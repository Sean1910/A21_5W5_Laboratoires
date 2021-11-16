using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
  public class CountryRepository : RepositoryAsync<Country>, ICountryRepository
  {
    private readonly JungleDbContext _db;

    public CountryRepository(JungleDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(Country country)
    {
      _db.Update(country);

    }
  }
}
