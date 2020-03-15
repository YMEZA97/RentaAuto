using Domain.Business;
using System;
using System.Collections.Generic;
using System.Text;
using Data.DbModels;
using System.Linq;

namespace Data.Repositorio
{
    class MecanicoRepository : IMecanicoRepository
    {

        #region Files
        private readonly DB_Context db;
        #endregion
        public MecanicoRepository()
        {
            db = new DB_Context();
        }


        public bool Delete(int id)
        {
            try
            {
                var data = db.TMecanico.Find(id);
                db.TMecanico.Remove(data);
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
                var data = db.TMecanico.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Mecanico> GetAll()
        {
            try
            {
                var data = db.TMecanico.Select(x => new Mecanico()
                {
                    IdBase = x.IdBase,
                    Nombre = x.Nombre,
                    Apellido = x.Apellido,
                    NumeroTelefono = x.NumeroTelefono,
                    Salario = x.Salario,
                    FechaContratacion = x.FechaContratacion
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Mecanico GetById(int id)
        {
            try
            {
                var data = db.TMecanico.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Mecanico m)
        {
            try
            {
                var dbTable = ConvertToDBTable(m);
                db.TMecanico.Add(dbTable);
                db.SaveChanges();
                int i = dbTable.IdMecanico;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Mecanico m)
        {
            try
            {
                var data = db.TMecanico.Find(m.IdMecanico);
                if (data != null)
                {
                    db.TMecanico.Update(ConvertToDBTable(m));
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
                return false;
                throw;
            }
        }

        public TMecanico ConvertToDBTable(Mecanico m)
        {
            return new TMecanico
            {
                IdBase = m.IdBase,
                Nombre = m.Nombre,
                Apellido = m.Apellido,
                NumeroTelefono = m.NumeroTelefono,
                Salario = m.Salario,
                FechaContratacion = m.FechaContratacion

            };
        }

        public Mecanico ConvertToDomain(TMecanico m)
        {
            return new Mecanico
            {
                IdBase = m.IdBase,
                Nombre = m.Nombre,
                Apellido = m.Apellido,
                NumeroTelefono = m.NumeroTelefono,
                Salario = m.Salario,
                FechaContratacion = m.FechaContratacion
            };
        }




    }
}
