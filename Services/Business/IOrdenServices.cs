using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business
{
  public  interface IOrdenServices
    {
        public bool Save(Orden b);
        public Orden GetById(int id);
        public bool Delete(int id);
        public bool Update(Orden b);
        public IEnumerable<Orden> GetAll();
        public bool Exist(string valor);
    }
}
