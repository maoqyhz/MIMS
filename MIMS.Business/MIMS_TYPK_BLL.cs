using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.IBusiness;
using MIMS.Entity;
using System.Collections;
using MIMS.Service;

namespace MIMS.Business
{
    public class MIMS_TYPK_BLL : IMIMS_TYPK_BLL
    {
        private static readonly MIMS_TYPK_DAL dal = new MIMS_TYPK_DAL();
        //public IList<MIMS_TYPK> GetList()
        //{
        //    return dal.GetList();
        //}

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
                prams.Add("@PYDM", "%" + query + "%");
                where = " AND PYDM like @PYDM";
            }
            return dal.GetPageListWhere(new StringBuilder(where), prams, orderField, orderType, pageIndex, pageSize, ref count);
        }
    }


}
