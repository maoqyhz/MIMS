using MIMS.Entity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MIMS.IBusiness
{
    public interface IPSS_PurchasePlanDetailBLL
    {

        /// <summary>
        /// 获取一个list的数据
        /// </summary>
        /// <returns></returns>
        IList GetList();
        IList GetPageList(string query, string orderField, string orderType, int pageIndex, int pageSize, ref int count);

        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PSS_PurchasePlanDetail GetEntity(string id);
        int Insert(PSS_PurchasePlanDetail obj);
        int Delete(PSS_PurchasePlanDetail obj);

    }
}
