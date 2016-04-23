using MIMS.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MIMS.Service;
using MIMS.Entity.Model;
using MIMS.Entity.Dtos;
namespace MIMS.Business
{
    public class PSS_PurchasePlanDetailBLL : IPSS_PurchasePlanDetailBLL
    {
        private static readonly PSS_PurchasePlanDetailDAL dal = new PSS_PurchasePlanDetailDAL();

        public IList GetList()
        {
            return dal.GetList();
        }

        public IList GetPageList(string query, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            string where = string.Empty;
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(query))
            {
                prams.Add("@PurchaseNo", query);
                where = " AND PurchaseNo = @PurchaseNo";
            }
            IList list = dal.GetPageListWhere(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
            foreach (Dto_PurchasePlanDetail item in list)
                item.InWarehouseSum = item.InWarehousePrice * item.PurchaseNum;
            return list;
        }

        public PSS_PurchasePlanDetail GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Insert(PSS_PurchasePlanDetail obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(PSS_PurchasePlanDetail obj)
        {
            return dal.Delete(obj);
        }
    }
}
