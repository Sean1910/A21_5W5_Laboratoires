using ChampsSpeciaux.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChampsSpeciaux.Repository.IRepository
{
    public interface ITravelRepository : IRepositoryAsync<Travel>
    {
        void Update(Travel travel);
    }
}
