using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
  public class TravelRepository : RepositoryAsync<Travel>, ITravelRepository
  {
    private readonly JungleDbContext _db;

    public TravelRepository(JungleDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(Travel travel)
    {
      _db.Update(travel);

    }
  }
}
