using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;

namespace Data.Repositorio
{
  public  interface IAutoRepository
    {
        public bool Save(Auto b);
        public Auto GetById(int id);
        public bool Delete(int id);
        public bool Update(Auto b);
        public IEnumerable<Auto> GetAll();
        public bool Exist(int id);
    }
}
