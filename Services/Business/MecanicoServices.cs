using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Data.Repositories;
using Domain.Business;
using Data.Repositorio;

namespace Services.Business
{
    public class MecanicoServices : IMecanicoServices
    {
        #region FIELDS
        [Dependency]
        #endregion
        public IMecanicoRepository mecanicoRepository { set; get; }
        public bool Delete(int id)
        {
            return mecanicoRepository.Delete(id);
        }

        public bool Exist(int id)
        {
            return mecanicoRepository.Exist(id);
        }

        public IEnumerable<Mecanico> GetAll()
        {
            return mecanicoRepository.GetAll();
        }

        public Mecanico GetById(int id)
        {
            return mecanicoRepository.GetById(id);
        }

        public bool Save(Mecanico m)
        {
            return mecanicoRepository.Save(m);
        }

        public bool Update(Mecanico m)
        {
            return mecanicoRepository.Update(m);
        }
    }
}
