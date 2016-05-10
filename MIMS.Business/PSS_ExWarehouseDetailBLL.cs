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
    public class PSS_ExWarehouseDetailBLL : IPSS_ExWarehouseDetailBLL
    {
        private static readonly PSS_ExWarehouseDetailDAL dal = new PSS_ExWarehouseDetailDAL();
        private static readonly PHA_AccountsDAL accountsDal = new PHA_AccountsDAL();

        public IList GetList(Hashtable ht)
        {
            string where = string.Empty;
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (ht["EWID"] != null && !string.IsNullOrEmpty(ht["EWID"].ToString()))
            {
                where += " AND EWID = @EWID";
                prams.Add("@EWID", ht["EWID"]);
            }
            if (ht["PhaCode"] != null && !string.IsNullOrEmpty(ht["PhaCode"].ToString()))
            {
                where += " AND PhaCode = @PhaCode";
                prams.Add("@PhaCode", ht["PhaCode"]);
            }
            if (ht["OrginID"] != null && !string.IsNullOrEmpty(ht["OrginID"].ToString()))
            {
                where += " AND OrginID = @OrginID";
                prams.Add("@OrginID", ht["OrginID"]);
            }
            if ((ht["startDate"] != null && !string.IsNullOrEmpty(ht["startDate"].ToString())) ||
                (ht["endDate"] != null && !string.IsNullOrEmpty(ht["endDate"].ToString())))
            {
                where += string.Format(" AND EWDate >= '{0}' AND EWDate <= '{1}'",
                    ht["startDate"].ToString(), ht["endDate"].ToString());
            }
            return dal.GetList(prams, where);
        }

        public IList GetPageList(string query, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            string where = string.Empty;
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(query))
            {
                prams.Add("@EWID", query);
                where = " AND EWID = @EWID";
            }
            IList list = dal.GetPageListWhere(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
            return list;
        }

        public PSS_ExWarehouseDetail GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Insert(PSS_ExWarehouseDetail obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(PSS_ExWarehouseDetail obj)
        {
            return dal.Delete(obj);
        }
        public IList SearchPhaListByDate(string startDate, string endDate, Hashtable ht, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            string where = string.Format(" AND EWDate >= '{0}' AND EWDate <= '{1}'", startDate, endDate);
            Dictionary<string, object> prams = new Dictionary<string, object>();
            IEnumerable<Dto_ExWarehouseDetail> list = dal.SearchInDatePha(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
            PHA_Accounts temp;
            foreach (Dto_ExWarehouseDetail item in list)
            {
                temp = accountsDal.GetEntity(item.PhaCode, item.OrginID.ToString());
                item.PinyinCode = temp.PinyinCode;
                item.PhaName = temp.PhaName;
                item.Spec = temp.Spec;
                item.Unit = temp.Unit;
                item.OrginName = temp.OrginName;
            }
            if (ht["PinyinCode"] != null && !string.IsNullOrEmpty(ht["PinyinCode"].ToString()))
                list = list.Where(r => r.PinyinCode.Contains(ht["PinyinCode"].ToString()));
            return list.ToList();
        }
    }
}
