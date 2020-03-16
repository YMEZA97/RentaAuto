using Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.DbModels.Repositories
{
    public class AgenteRepository : IAgenteRepository
    {
        #region Fiels
        private readonly DB_Context db;

        public AgenteRepository()
        {
            db = new DB_Context();
        }
        public bool Delete(int id)
        {
            try
            {
                var data = db.TAgente.Find(id);
                db.TAgente.Remove(data);
                db.SaveChanges();
                return true;
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

        public IEnumerable<Agente> GetAll()
        {
            try
            {
                var data = db.TAgente.Select(x => new Agente()
                {
                    IdAgente = x.IdAgente,
                    IdBase = x.IdBase,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Salario = x.Salario,
                    NumeroTelefono = x.NumeroTelefono,
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Agente GetbyId(int id)
        {
            try
            {
                var data = db.TAgente.Find(id);
                return data != null ? ConvertToDBDDomain(data) : null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool save(Agente a)
        {
            try
            {
                var dbtable = ConvertToDBTable(a);
                db.TAgente.Add(dbtable);
                db.SaveChanges();

                int i = dbtable.IdAgente;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Agente a)
        {
            try
            {
                var data = db.TAgente.Find(a.IdAgente);
                if (data != null)
                {
                    data.IdBase = a.IdBase;
                    data.IdAgente = a.IdAgente;
                    data.Nombre = a.Nombre;
                    data.Apellido = a.Apellido;
                    data.NumeroTelefono = a.NumeroTelefono;
                    data.Salario = a.Salario;
                    

                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Other Methos

        public TAgente ConvertToDBTable(Agente a)
        {
            return new TAgente
            {
            IdBase = a.IdBase,
            IdAgente = a.IdAgente,
            Nombre = a.Nombre,
            Apellido = a.Apellido,
            NumeroTelefono = a.NumeroTelefono,
            Salario = a.Salario
        };
        }
        public Agente ConvertToDBDDomain(TAgente a)
        {
            return new Agente
            {
                IdBase = a.IdBase,
                IdAgente = a.IdAgente,
                Nombre = a.Nombre,
                Apellido = a.Apellido,
                NumeroTelefono = a.NumeroTelefono,
                Salario = a.Salario
            };
        }
    }
}
