using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;

namespace Data.Repositorio
{
    interface IMecanicoRepository
    {

        public bool Save(Mecanico m);
        public Mecanico GetById(int id);
        public bool Delete(int id);
        public bool Update(Mecanico m);
        public IEnumerable<Mecanico> GetAll();
        public bool Exist(int id);


    }
}
