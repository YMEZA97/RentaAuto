using Data.DbModels.Repositories;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Services.Business
{
    public class AgenteServices : IAgenteServices
    {

        #region FIELDS
        [Dependency]
        public IAgenteRepository agenteRepository { get; set; }
        #endregion FIELDS

        public bool Delete(int id)
        {
            return agenteRepository.Delete(id);
        }

        public bool Exist(string valor)
        {
            return agenteRepository.Exist(valor);
        }

        public IEnumerable<Agente> GetAll()
        {
            return agenteRepository.GetAll();
        }

        public Agente GetbyId(int id)
        {
            return agenteRepository.GetbyId(id);
        }

        public bool save(Agente a)
        {
            return agenteRepository.save(a);
        }

        public bool Update(Agente a)
        {
            return agenteRepository.Update(a);
        }
    }
}
