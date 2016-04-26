using MIMS.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MIMS.Service;
using MIMS.Entity.Model;

namespace MIMS.Business
{
    public class PSS_ExWarehouseBLL :IPSS_ExWarehouseBLL
    {
        private static readonly PSS_ExWarehouseDAL dal = new PSS_ExWarehouseDAL();
        public IList GetList()
        {
            return dal.GetList();
        }

        public PSS_ExWarehouse GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Update(PSS_ExWarehouse obj)
        {
            return dal.Update(obj);
        }

        public int Insert(PSS_ExWarehouse obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(PSS_ExWarehouse obj)
        {
            return dal.Delete(obj);
        }
    }
}
