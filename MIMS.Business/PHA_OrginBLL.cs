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
    public class PHA_OrginBLL : IPHA_OrginBLL
    {
        private static readonly PHA_OrginDAL dal = new PHA_OrginDAL();
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
                prams.Add("@PinyinCode", "%" + query + "%");
                where = " AND PinyinCode like @PinyinCode";
            }
            return dal.GetPageListWhere(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
        }

        public PHA_Orgin GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Update(PHA_Orgin obj)
        {
            return dal.Update(obj);
        }

        public int Insert(PHA_Orgin obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(PHA_Orgin obj)
        {
            return dal.Delete(obj);
        }
    }
}
