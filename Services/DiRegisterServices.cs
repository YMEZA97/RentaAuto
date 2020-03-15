using System;
using System.Collections.Generic;
using System.Text;
using Utils.DInjection;
using Services.Business;
using Data;

namespace Services
{
    public class DiRegisterServices
    {
        public static List<IClassType> GetServiceList()
        {
            var list = new List<IClassType>();
            list.AddRange(DiRegisterData.GetDataList());
            list.Add(new ClassType<IBaseServices, BaseServices>());
            list.Add(new ClassType<IClienteServices, ClienteServices>());
            return list;
        }
    }
}
