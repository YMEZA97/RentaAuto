using Data.DbModels.Repositories;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Services.Business
{
    public class ClienteServices : IClienteServices
    {


        #region FIELDS
        [Dependency]
        public IClienteRepository clienteRepository { get; set; }
        #endregion FIELDS
        public bool Delete(int id)
        {
            return clienteRepository.Delete(id);
        }

        public bool Exist(string valor)
        {
            return clienteRepository.Exist(valor);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return clienteRepository.GetAll();
        }

        public Cliente GetbyId(int id)
        {
            return clienteRepository.GetbyId(id);
        }

        public bool save(Cliente c)
        {
            return clienteRepository.save(c);
        }

        public bool Update(Cliente c)
        {
            return clienteRepository.Update(c);
        }
    }
}
