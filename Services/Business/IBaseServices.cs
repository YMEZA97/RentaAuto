using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business
{
     public interface IBaseServices
    {
        public bool Save(Base b);
        public Base GetById(int id);
        public bool Delete(int id);
        public bool Update(Base b);
        public IEnumerable<Base> GetAll();
        public bool Exist(string valor);

    }
}
