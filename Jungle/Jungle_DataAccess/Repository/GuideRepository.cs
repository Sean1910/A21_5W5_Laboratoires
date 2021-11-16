using Jungle_DataAccess.Repository.IRepository;
using Jungle_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository
{
  public class GuideRepository : RepositoryAsync<Guide>, IGuideRepository
  {
    private readonly JungleDbContext _db;

    public GuideRepository(JungleDbContext db) : base(db)
    {
      _db = db;
    }

    public void Update(Guide guide)
    {
      _db.Update(guide);

    }
  }
}
