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

        public IList GetList(Hashtable ht)
        {
            string where = string.Empty;
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (ht["EWID"] != null && !string.IsNullOrEmpty(ht["EWID"].ToString()))
            {
                where = " AND EWID = @EWID";
                prams.Add("@EWID", ht["EWID"]);
            }
            if (ht["PhaCode"] != null && !string.IsNullOrEmpty(ht["PhaCode"].ToString()))
            {
                where = " AND PhaCode = @PhaCode";
                prams.Add("@PhaCode", ht["PhaCode"]);
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
            if (ht["PinyinCode"] != null && !string.IsNullOrEmpty(ht["PinyinCode"].ToString()))
            {
                where += " AND PinyinCode like @PinyinCode";
                prams.Add("@PinyinCode", '%' + ht["PinyinCode"].ToString() + '%');
            }
            IList list = dal.SearchInDatePha(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
            return list;
        }
    }
}
