using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Data.DbModels;
using System.Linq;

namespace Data.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        #region Fields
        private readonly DB_Context db;
        #endregion 

        public BaseRepository()
        {
            db = new DB_Context();
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.TBase.Find(id);
                db.TBase.Remove(data);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(int id)
        {
            try
            {
                var data = db.TBase.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Exist(string valor)
        {
            try
            {
                var data = db.TBase.Any(x => x.Nombre == valor);
                return data;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public MiObjetoRetorno obtenerInfoAgente(int id)
        {
            MiObjetoRetorno m = new MiObjetoRetorno();
            var agente = db.TAgente.Find(id);

            m.NombreAgente = agente.Nombre;
            m.Salario = agente.Salario;
            m.Ciudad = agente.IdBaseNavigation.Ciudad;

            return m;
        }

        public IEnumerable<Base> GetAll()
        {
            try
            {
                var data = db.TBase.Select(x => new Base() 
                { IdBase = x.IdBase, 
                  Nombre = x.Nombre,
                  Direccion = x.Direccion,
                  Ciudad = x.Ciudad,
                  NumeroTelefono = x.NumeroTelefono,
                  Region = x.Region
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Base GetById(int id)
        {
            try
            {
                var data = db.TBase.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Base b)
        {
            try
            {
                var dbTable = ConvertToDBTable(b);
                db.TBase.Add(dbTable);
                db.SaveChanges();
                int i = dbTable.IdBase;

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }

        public bool Update(Base b)
        {
            try
            {
                var data = db.TBase.Find(b.IdBase);
                if (data != null)
                {
                    data.Nombre = b.Nombre;
                    data.Region = b.Region;
                    data.Ciudad = b.Ciudad;
                    data.Direccion = b.Direccion;
                    data.NumeroTelefono = b.NumeroTelefono;
                    
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }
        

        #region OtherMethos

        public TBase ConvertToDBTable(Base b)
        {
            return new TBase
            {
                
                Nombre = b.Nombre,
                Region = b.Region,
                Ciudad = b.Ciudad,
                Direccion = b.Direccion,
                NumeroTelefono = b.NumeroTelefono
            };
        }

        public Base ConvertToDomain(TBase b)
        {
            return new Base
            {
                IdBase = b.IdBase,
                Nombre = b.Nombre,
                Region = b.Region,
                Ciudad = b.Ciudad,
                Direccion = b.Direccion,
                NumeroTelefono = b.NumeroTelefono
            };
        }

        #endregion

    }
}
