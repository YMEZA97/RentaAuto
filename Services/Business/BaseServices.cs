using Data.Repositories;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Services.Business
{
    public class BaseServices : IBaseServices
    {
        #region FIELDS
        [Dependency]
        #endregion
        public IBaseRepository baseRepository { get; set; }
        
        public bool Delete(int id)
        {
            return baseRepository.Delete(id);
        }

        public bool Exist(string valor)
        {
            return baseRepository.Exist(valor);
        }

        public IEnumerable<Base> GetAll()
        {
            return baseRepository.GetAll();
        }

        public Base GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public bool Save(Base b)
        {
            return baseRepository.Save(b);
        }

        public bool Update(Base b)
        {
            return baseRepository.Update(b);
        }
    }
}
