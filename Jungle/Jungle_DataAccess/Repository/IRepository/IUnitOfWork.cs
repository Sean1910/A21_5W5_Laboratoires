using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Repository.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    ICountryRepository Country { get; }
    IDestinationRepository Destination { get; }
    IGuideRepository Guide { get; }
    ITravelRepository Travel { get; }
    ITravelRecommendationRepository TravelRecommendation { get; }

    void Save();
  }
}
