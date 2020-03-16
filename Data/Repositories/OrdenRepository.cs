using Data.DbModels;
using Domain.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories
{
    class OrdenRepository : IOrdenRepository
    {



        #region Field
        private readonly DB_Context db;
        #endregion

        public OrdenRepository()
        {
            db = new DB_Context();
        }


        public bool Delete(int id)
        {
            try
            {
                var data = db.TOrden.Find(id);
                db.TOrden.Remove(data);
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
                var data = db.TOrden.Find(valor);
                return data != null ? true : false;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Orden> GetAll()
        {
            try
            {
                var data = db.TOrden.Select(x => new Orden()
                {
                    IdOrden = x.IdOrden,
                    IdCliente = x.IdCliente,
                    IdAuto = x.IdAuto,
                    Fecha = x.Fecha,
                    RentaFechaInicio = x.RentaFechaInicio,
                    RentaFechaFin = x.RentaFechaFin,
                    FechaCancelacion = x.FechaCancelacion,
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Orden GetById(int id)
        {
            try
            {
                var data = db.TOrden.Find(id);
                return data != null ? ConverToBDDomainOrden(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Orden b)
        {
            try
            {
                var dbTable = ConverToBDTableOrden(b);
                db.TOrden.Add(dbTable);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Orden b)
        {
            try
            {
                var data = db.TOrden.Find(b.IdAuto);
                if (data != null)
                {
                    db.TOrden.Update(ConverToBDTableOrden(b));
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

        public TOrden ConverToBDTableOrden(Orden b)
        {
            return new TOrden
            {
                IdOrden = b.IdOrden,
                IdCliente = b.IdCliente,
                IdAuto = b.IdAuto,
                Fecha = b.Fecha,
                RentaFechaInicio = b.RentaFechaInicio,
                RentaFechaFin = b.RentaFechaFin,
                FechaCancelacion = b.FechaCancelacion,

            };
        }


        public Orden ConverToBDDomainOrden(TOrden b)
        {
            return new Orden
            {

                IdOrden = b.IdOrden,
             IdCliente = b.IdCliente,
             IdAuto = b.IdAuto,
             Fecha = b.Fecha,
             RentaFechaInicio = b.RentaFechaInicio,
             RentaFechaFin = b.RentaFechaFin,
             FechaCancelacion = b.FechaCancelacion,
                            
            };
        }

    }
}
