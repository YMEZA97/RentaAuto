using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business
{
    public interface IAgenteServices
    {
        public bool save(Agente a);

        public Agente GetbyId(int id);

        public bool Delete(int id);

        public bool Update(Agente a);

        public IEnumerable<Agente> GetAll();

        public bool Exist(string valor);
    }
}
