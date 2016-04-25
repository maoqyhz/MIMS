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
    public class PSS_InWarehouseBLL:IPSS_InWarehouseBLL
    {

        private static readonly PSS_InWarehouseDAL dal = new PSS_InWarehouseDAL();
        public IList GetList()
        {
            return dal.GetList();
        }

        public PSS_InWarehouse GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Update(PSS_InWarehouse obj)
        {
            return dal.Update(obj);
        }

        public int Insert(PSS_InWarehouse obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(PSS_InWarehouse obj)
        {
            return dal.Delete(obj);
        }
    }
}
