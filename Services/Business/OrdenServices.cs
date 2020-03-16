using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Services.Business
{
    class OrdenServices : IOrdenServices
    {



        #region FIELDS
        [Dependency]
        #endregion
        public IOrdenServices OrdenRepository { get; set; }

        public bool Delete(int id)
        {
            return OrdenRepository.Delete(id);
        }

        public bool Exist(string valor)
        {
            return OrdenRepository.Exist(valor);
        }

        public IEnumerable<Orden> GetAll()
        {
            return OrdenRepository.GetAll();
        }

        public Orden GetById(int id)
        {
            return OrdenRepository.GetById(id);
        }

        public bool Save(Orden b)
        {
            return OrdenRepository.Save(b);
        }

        public bool Update(Orden b)
        {
            return OrdenRepository.Update(b);
        }

    }
}
