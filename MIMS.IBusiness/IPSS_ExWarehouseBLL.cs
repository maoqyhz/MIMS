using MIMS.Entity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMS.IBusiness
{
    public interface IPSS_ExWarehouseBLL
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
        PSS_ExWarehouse GetEntity(string id);

        int Update(PSS_ExWarehouse obj);

        int Insert(PSS_ExWarehouse obj);
        int Delete(PSS_ExWarehouse obj);
    }
}
