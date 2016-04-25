using MIMS.Entity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MIMS.IBusiness
{
    public interface IPSS_InWarehouseBLL
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
        PSS_InWarehouse GetEntity(string id);

        int Update(PSS_InWarehouse obj);

        int Insert(PSS_InWarehouse obj);
        int Delete(PSS_InWarehouse obj);
    }
}
