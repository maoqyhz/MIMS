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
    public class PSS_PurchasePlanBLL : IPSS_PurchasePlanBLL
    {
        private static readonly PSS_PurchasePlanDAL dal = new PSS_PurchasePlanDAL();
        public IList GetList()
        {
            return dal.GetList();
        }

        public PSS_PurchasePlan GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Update(PSS_PurchasePlan obj)
        {
            return dal.Update(obj);
        }

        public int Insert(PSS_PurchasePlan obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(PSS_PurchasePlan obj)
        {
            return dal.Delete(obj);
        }
    }
}
