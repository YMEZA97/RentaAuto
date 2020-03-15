using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Domain.Business;
using Data.Repositorio;

namespace Services.Business
{
    class AutoServices : IAutoServices
    {


        #region FIELDS
        [Dependency]
        #endregion
        public IAutoRepository AutoRepository { get; set; }

        public bool Delete(int id)
        {
            return AutoRepository.Delete(id);
        }

        public bool Exist(string valor)
        {
            return AutoRepository.Exist(valor);
        }

        public IEnumerable<Auto> GetAll()
        {
            return AutoRepository.GetAll();
        }

        public Auto GetById(int id)
        {
            return AutoRepository.GetById(id);
        }

        public bool Save(Auto b)
        {
            return AutoRepository.Save(b);
        }

        public bool Update(Auto b)
        {
            return AutoRepository.Update(b);
        }

    }
}
