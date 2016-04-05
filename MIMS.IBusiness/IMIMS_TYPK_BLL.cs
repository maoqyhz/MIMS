using MIMS.Entity;
using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMS.IBusiness
{
    /// <summary>
    /// 药品基本库表的业务逻辑
    /// </summary>

    public interface IMIMS_TYPK_BLL
    {
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
        IList GetPageList(string query, string orderField,string orderType, int pageIndex, int pageSize, ref int count);
    }
}
