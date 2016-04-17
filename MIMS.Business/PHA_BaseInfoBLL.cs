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
    public class PHA_BaseInfoBLL : IPHA_BaseInfoBLL
    {
        private static readonly PHA_BaseInfoDAL dal = new PHA_BaseInfoDAL();
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="query">搜索键值</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">总条数</param>
        /// <returns></returns>
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
        public PHA_BaseInfo GetEntity(string id)
        {
            return dal.GetEntity(id);
        }


        public int Update(PHA_BaseInfo obj)
        {
            return dal.Update(obj);
        }




        public int Delete(PHA_BaseInfo obj)
        {
            return dal.Delete(obj);
        }


        public int Insert(PHA_BaseInfo obj)
        {
            return dal.Insert(obj);
        }
    }
}
