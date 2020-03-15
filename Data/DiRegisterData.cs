using System;
using System.Collections.Generic;
using System.Text;
using Utils.DInjection;
using Data.Repositories;
using Data.Repositorio;
using Data.DbModels.Repositories;

namespace Data
{
    public class DiRegisterData
    {
        public static List<IClassType> GetDataList()
        {
            var list = new List<IClassType>();
            list.Add(new ClassType<IBaseRepository, BaseRepository >());
            list.Add(new ClassType<IClienteRepository, ClienteRepository>());
            return list;
        }
    }
}
