using MIMS.Entity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMS.IBusiness
{
    public interface ICOM_UserBLL
    {
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        COM_User GetEntity(string id);

        int Update(COM_User obj);

        int Insert(COM_User obj);
        int Delete(COM_User obj);

    }
}
