using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;

namespace Services.Business
{
    public interface IMecanicoServices
    {
        public bool Save(Mecanico m);
        public Mecanico GetById(int id);
        public bool Delete(int id);
        public bool Update(Mecanico m);
        public IEnumerable<Mecanico> GetAll();
        public bool Exist(string valor);
    }
}
