using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppDependencyInject_Lab.Service.LifeTimeExample
{
  public class SingletonService
  {
    private readonly Guid guid;

    public SingletonService()
    {
      guid = Guid.NewGuid();
    }
    public string GetGuid() => guid.ToString();
  }
}
