using AppDependencyInject_Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDependencyInject_Lab.Service
{
  public class ZombieForecasterV2

  {
    public NbrZombiesResult GetVillagePrediction()
    {
    
      return new NbrZombiesResult
      {
        NbrZombiesCondition = NbrZombiesCondition.Imprevisible
      };
    }
  }


}