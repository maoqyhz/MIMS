using MIMS.Entity;
using System;
using System.Collections.Generic;
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
        IList<MIMS_TYPK> GetList();
    }
}
