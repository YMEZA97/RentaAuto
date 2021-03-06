﻿using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;

namespace Data.DbModels.Repositories
{
   public interface IClienteRepository
    {
        
        public bool save(Cliente c);

        public Cliente GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Cliente c);

        public IEnumerable<Cliente> GetAll();

        public bool Exist(string valor);
        


    }
}
