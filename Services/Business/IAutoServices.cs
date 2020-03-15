using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;

namespace Services.Business
{
   public interface IAutoServices
    {
        public bool Save(Auto b);
        public Auto GetById(int id);
        public bool Delete(int id);
        public bool Update(Auto b);
        public IEnumerable<Auto> GetAll();
        public bool Exist(string valor);
        
    }
}
