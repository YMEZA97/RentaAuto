using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business
{
    public interface IClienteServices
    {
        public bool save(Cliente c);

        public Cliente GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Cliente c);

        public IEnumerable<Cliente> GetAll();

        public bool Exist(string valor);

    }
}
