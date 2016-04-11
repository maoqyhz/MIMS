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
    public class PSS_ExWarehouseModeBLL:IPSS_ExWarehouseModeBLL
    {

        private static readonly PSS_ExWarehouseModeDAL dal = new PSS_ExWarehouseModeDAL();
        /// <summary>
        /// 获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public IList GetList()
        {
            return dal.GetList();
        }
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PSS_ExWarehouseMode GetEntity(string id)
        {
            return dal.GetEntity(id);
        }


        public int Update(PSS_ExWarehouseMode obj)
        {
            return dal.Update(obj);
        }
        public int Insert(PSS_ExWarehouseMode obj)
        {
            return dal.Insert(obj);
        }


        public int Delete(PSS_ExWarehouseMode obj)
        {
            return dal.Delete(obj);
        }
    }
}
