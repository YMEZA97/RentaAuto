using System;
using System.Collections.Generic;
using System.Text;
using Data.DbModels;
using System.Linq;
using Domain.Business;

namespace Data.Repositories
{
    public class ReparacionRepository : IReparacionRepository
    {
        #region Files
        private readonly DB_Context db;
        #endregion
        public ReparacionRepository()
        {
            db = new DB_Context();
        }

        public bool Delete(int id)
        {
            try
            {
                var data = db.TReparacion.Find(id);
                db.TReparacion.Remove(data);
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
                var data = db.TReparacion.Find(id);
                return data != null ? true : false;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Reparacion> GetAll()
        {
            try
            {
                var data = db.TReparacion.Select(x => new Reparacion()
                {
                    IdAuto = x.IdAuto,
                    IdMecanico = x.IdMecanico,
                    Fecha = x.Fecha,
                    Costo = x.Costo
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Reparacion GetById(int id)
        {
            try
            {
                var data = db.TReparacion.Find(id);
                return data != null ? ConvertToDomain(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Reparacion r)
        {
            try
            {
                var dbTable = ConvertToDBTable(r);
                db.TReparacion.Add(dbTable);
                db.SaveChanges();
                int i = dbTable.IdReparacion;
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Reparacion r)
        {
            try
            {
                var data = db.TReparacion.Find(r.IdMecanico);
                if (data != null)
                {
                    db.TReparacion.Update(ConvertToDBTable(r));
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

        public TReparacion ConvertToDBTable(Reparacion r)
        {
            return new TReparacion
            {
                IdAuto = r.IdAuto,
                IdMecanico = r.IdMecanico,
                Fecha = r.Fecha,
                Costo = r.Costo

            };
        }

        public Reparacion ConvertToDomain(TReparacion r)
        {
            return new Reparacion
            {
                IdAuto = r.IdAuto,
                IdMecanico = r.IdMecanico,
                Fecha = r.Fecha,
                Costo = r.Costo
            };
        }


    }
}
