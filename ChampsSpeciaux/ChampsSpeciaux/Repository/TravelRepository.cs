using ChampsSpeciaux.Data;
using ChampsSpeciaux.Repository.IRepository;
using ChampsSpeciaux.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChampsSpeciaux.Repository
{
    public class TravelRepository : RepositoryAsync<Travel>, ITravelRepository
    {
        private readonly ApplicationDbContext _db;

        public TravelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Travel travel)
        {
            _db.Update(travel);
        }
    }
}
