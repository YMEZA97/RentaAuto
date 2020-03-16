using System;
using System.Collections.Generic;
using System.Text;
using Domain.Business;
using Data.DbModels;
using System.Linq;

namespace Data.Repositorio
{
    class AutoRepository : IAutoRepository
    {

        #region Field
        private readonly DB_Context db;
        #endregion

        public AutoRepository()
        {
            db = new DB_Context();
        }


        public bool Delete(int id)
        {
            try
            {
                var data = db.TAuto.Find(id);
                db.TAuto.Remove(data);
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
                var data = db.TAuto.Find(valor);
                return data != null ? true : false;

            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public IEnumerable<Auto> GetAll()
        {
            try
            {
                var data = db.TAuto.Select(x => new Auto()
                {
                    IdBase = x.IdBase,
                    Marca = x.Marca,
                    Modelo = x.Modelo,
                    NumeroRegistro = x.NumeroRegistro,
                    AnioProduccion = x.AnioProduccion,
                    PrecioRenta = x.PrecioRenta,
                    Categoria = x.Categoria,
                });

                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public Auto GetById(int id)
        {
            try
            {
                var data = db.TAuto.Find(id);
                return data != null ? ConverToBDDomainAuto(data) : null;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }

        public bool Save(Auto b)
        {
            try
            {
                var dbTable = ConverToBDTableAuto(b);
                db.TAuto.Add(dbTable);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool Update(Auto b)
        {
            try
            {
                var data = db.TAuto.Find(b.IdAuto);
                if (data != null)
                {
                    db.TAuto.Update(ConverToBDTableAuto(b));
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

        public TAuto ConverToBDTableAuto(Auto b)
        {
            return new TAuto
            {
                
                IdBase = b.IdBase,
                Marca = b.Marca,
                Modelo = b.Modelo,
                NumeroRegistro = b.NumeroRegistro,
                AnioProduccion = b.AnioProduccion,
                PrecioRenta = b.PrecioRenta,
                Categoria = b.Categoria
            };
        }


        public Auto ConverToBDDomainAuto(TAuto b)
        {
            return new Auto
            {
                IdBase = b.IdBase,
                Marca = b.Marca,
                Modelo = b.Modelo,
                NumeroRegistro = b.NumeroRegistro,
                AnioProduccion = b.AnioProduccion,
                PrecioRenta = b.PrecioRenta,
                Categoria = b.Categoria,
            };
        }



    }
}
