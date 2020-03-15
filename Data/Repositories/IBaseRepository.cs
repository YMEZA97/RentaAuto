using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;

namespace Data.Repositories
{
    public interface IBaseRepository
    {
        public bool Save(Base b);
        public Base GetById(int id);
        public bool Delete(int id);
        public bool Update(Base b);
        public IEnumerable<Base> GetAll();
        public bool Exist(string valor);



    }
}
