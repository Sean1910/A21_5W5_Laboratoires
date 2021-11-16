using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
  public class TravelRecommendationRepository : RepositoryAsync<TravelRecommendation>, ITravelRecommendationRepository
  {
    private readonly JungleDbContext _db;

    public TravelRecommendationRepository(JungleDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(TravelRecommendation travelRecommendation)
    {
      _db.Update(travelRecommendation);

    }
  }
}
