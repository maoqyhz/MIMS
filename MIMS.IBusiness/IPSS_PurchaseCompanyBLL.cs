using MIMS.Entity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MIMS.IBusiness
{
    public interface IPSS_PurchaseCompanyBLL
    {
        /// <summary>
        /// 获取一个list的数据
        /// </summary>
        /// <returns></returns>
        IList GetList();
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PSS_PurchaseCompany GetEntity(string id);

        int Update(PSS_PurchaseCompany obj);

        int Insert(PSS_PurchaseCompany obj);
        int Delete(PSS_PurchaseCompany obj);
    }
}
