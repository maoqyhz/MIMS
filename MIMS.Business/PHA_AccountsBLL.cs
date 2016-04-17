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

        public IList GetPageList(string query, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            string where = string.Empty;
            Dictionary<string, object> prams = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(query))
            {
                prams.Add("@PinyinCode", "%" + query + "%");
                where = " AND PinyinCode like @PinyinCode";
            }
            return dal.GetPageListWhere(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
        }

        public PHA_Accounts GetEntity(string phaCode, string orginID)
        {
            return dal.GetEntity(phaCode,orginID);
        }
    }
}
