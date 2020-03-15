using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Data.DbModels;
using System.Linq;

namespace Data.DbModels.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        
        #region Fiels
        private readonly DB_Context db;

        public ClienteRepository()
        {
            db = new DB_Context();
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.TCliente.Find(id);
                db.TCliente.Remove(data);
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

        public IEnumerable<Cliente> GetAll()
        {
            try
            {
                var data = db.TCliente.Select(x => new Cliente()
                {
                    IdCliente = x.IdCliente,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    Direccion = x.Direccion,
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

        public Cliente GetbyId(int id)
        {
            try
            {
                var data = db.TCliente.Find(id);
                return data != null ? ConvertToDBDDomain(data) : null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool save(Cliente c)
        {
            try
            {
                var dbtable = ConvertToDBTable(c);
                db.TCliente.Add(dbtable);
                db.SaveChanges();

                int i = dbtable.IdCliente;
                return true;
            }
            catch (Exception )
            {
                return false;
                throw;
            }
        }

        public bool Update(Cliente c)
        {
            try
            {
                var data = db.TCliente.Find(c.IdCliente);
                if (data != null)
                {

                    db.TCliente.Update(ConvertToDBTable(c));
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

        public TCliente ConvertToDBTable(Cliente c)
        {
            return new TCliente
            {
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                NumeroTelefono = c.NumeroTelefono,
                Direccion = c.Direccion,
            };
        }
        public Cliente ConvertToDBDDomain(TCliente c)
        {
            return new Cliente
            {
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                NumeroTelefono = c.NumeroTelefono,
                Direccion = c.Direccion,
            };
        }

    }
}
