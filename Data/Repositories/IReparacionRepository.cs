using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;

namespace Data.Repositories
{
    public interface IReparacionRepository
    {
        public bool Save(Reparacion r);
        public Reparacion GetById(int id);
        public bool Delete(int id);
        public bool Update(Reparacion r);
        public IEnumerable<Reparacion> GetAll();
        public bool Exist(int id);
    }
}
