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
    public class PHA_AccountsBLL : IPHA_AccountsBLL
    {
        private static readonly PHA_AccountsDAL dal = new PHA_AccountsDAL();

        public IList GetPageList(Hashtable ht, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            StringBuilder where = new StringBuilder();
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (ht["CompanyID"] != null && !string.IsNullOrEmpty(ht["CompanyID"].ToString()))
            {
                where.Append(" AND CompanyID = @CompanyID");
                prams.Add("@CompanyID", ht["CompanyID"]);
            }
            if (ht["PinyinCode"] != null && !string.IsNullOrEmpty(ht["PinyinCode"].ToString()))
            {
                prams.Add("@PinyinCode", "%" + ht["PinyinCode"] + "%");
                where.Append(" AND PinyinCode like @PinyinCode");
            }
            return dal.GetPageListWhere(where, prams, orderField, orderType, pageIndex, pageSize, ref count);
        }

        public PHA_Accounts GetEntity(string phaCode, string orginID)
        {
            return dal.GetEntity(phaCode, orginID);
        }


        public int Update(PHA_Accounts obj)
        {
            return dal.Update(obj);
        }

        public int Delete(PHA_Accounts obj)
        {
            return dal.Delete(obj);
        }

        public int Insert(PHA_Accounts obj)
        {
            return dal.Insert(obj);
        }
    }
}
