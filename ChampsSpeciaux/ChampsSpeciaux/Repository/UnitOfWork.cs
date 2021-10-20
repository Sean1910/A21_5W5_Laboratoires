using ChampsSpeciaux.Data;
using ChampsSpeciaux.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChampsSpeciaux.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Travel = new TravelRepository(_db);
        }

        public ITravelRepository Travel { get; private set; }

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
