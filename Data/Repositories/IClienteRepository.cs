using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;

namespace Data.Repositorio
{
  interface IClienteRepository
    {

        public bool Save(Cliente c);

        public Cliente GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Cliente c);

        public IEnumerable<Cliente> GetAll();

        public bool Exist(int id);

    }
}
