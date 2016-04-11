using MIMS.Entity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMS.IBusiness
{
    public interface IPSS_ExWarehouseModeBLL
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
        PSS_ExWarehouseMode GetEntity(string id);

        int Update(PSS_ExWarehouseMode obj);

        int Insert(PSS_ExWarehouseMode obj);
        int Delete(PSS_ExWarehouseMode obj);
    }
}
