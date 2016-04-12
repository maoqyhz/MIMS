using MIMS.Entity.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMS.IBusiness
{
    public interface IPHA_RepositoryBLL
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
        PHA_Repository GetEntity(string id);

        int Update(PHA_Repository obj);

        int Insert(PHA_Repository obj);
        int Delete(PHA_Repository obj);
    }
}
