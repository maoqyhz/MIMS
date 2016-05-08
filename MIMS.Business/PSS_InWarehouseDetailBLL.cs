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
    public class PSS_InWarehouseDetailBLL : IPSS_InWarehouseDetailBLL
    {
        private static readonly PSS_InWarehouseDetailDAL dal = new PSS_InWarehouseDetailDAL();
        private static readonly PHA_AccountsDAL accountsDal = new PHA_AccountsDAL();

        public IList GetList(Hashtable ht)
        {
            string where = string.Empty;
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (ht["IWID"] != null && !string.IsNullOrEmpty(ht["IWID"].ToString()))
            {
                where += " AND IWID = @IWID";
                prams.Add("@IWID", ht["IWID"]);
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
                where += string.Format(" AND IWDate >= '{0}' AND IWDate <= '{1}'",
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
                prams.Add("@IWID", query);
                where = " AND IWID = @IWID";
            }
            IList list = dal.GetPageListWhere(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
            //foreach (Dto_InWarehouseDetail item in list)
            //    item.InWarehouseSum = item.InWarehousePrice * item.InWarehouseCount;
            return list;
        }

        public PSS_InWarehouseDetail GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Insert(PSS_InWarehouseDetail obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(PSS_InWarehouseDetail obj)
        {
            return dal.Delete(obj);
        }

        public IList SearchPhaListByDate(string startDate, string endDate, Hashtable ht, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            string where = string.Format(" AND IWDate >= '{0}' AND IWDate <= '{1}'", startDate, endDate);
            Dictionary<string, object> prams = new Dictionary<string, object>();
            IEnumerable<Dto_InWarehouseDetail> list = dal.SearchInDatePha(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
            PHA_Accounts temp;
            foreach (Dto_InWarehouseDetail item in list)
            {
                temp = accountsDal.GetEntity(item.PhaCode, item.OrginID.ToString());
                item.PinyinCode = temp.PinyinCode;
                item.PhaName = temp.PhaName;
                item.Spec = temp.Spec;
                item.Unit = temp.Unit;
                item.OrginID = temp.OrginID;
                item.OrginName = temp.OrginName;
            }
            if (ht["PinyinCode"] != null && !string.IsNullOrEmpty(ht["PinyinCode"].ToString()))
                list = list.Where(r => r.PinyinCode.Contains(ht["PinyinCode"].ToString()));
            return list.ToList();
        }
    }
}
