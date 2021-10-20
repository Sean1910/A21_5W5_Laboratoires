using ChampsSpeciaux.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChampsSpeciaux.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ITravelRepository Travel { get; }
        

        void Save();
    }
}
