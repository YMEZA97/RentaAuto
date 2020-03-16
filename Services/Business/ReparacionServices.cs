using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Data.Repositories;
using Domain.Business;

namespace Services.Business
{
    public class ReparacionServices : IReparacionServices
    {
        #region FIELDS
        [Dependency]
        #endregion
        public IReparacionRepository reparacionRepository { set; get; } 
        public bool Delete(int id)
        {
            return reparacionRepository.Delete(id);
        }

        public bool Exist(int id)
        {
            return reparacionRepository.Exist(id);
        }

        public IEnumerable<Reparacion> GetAll()
        {
            return reparacionRepository.GetAll();
        }

        public Reparacion GetById(int id)
        {
            return reparacionRepository.GetById(id);
        }

        public bool Save(Reparacion r)
        {
            return reparacionRepository.Save(r);
        }

        public bool Update(Reparacion r)
        {
            return reparacionRepository.Update(r);
        }
    }
}
