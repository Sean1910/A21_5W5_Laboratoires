using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppDependencyInject_Lab.Models;

namespace AppDependencyInject_Lab.Service
{
  interface IValidationChecker
  {
    bool ValidatorLogic(ZombiePartyApp model);
    string ErrorMessage { get; }
  }
}
