using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.IBusiness;
using MIMS.Service;
using MIMS.Entity;
using System.Collections;

namespace MIMS.Business
{
    public class PHA_DosageFormBLL :IPHA_DosageFormBLL
    {
        private static readonly PHA_DosageFormDAL dal = new PHA_DosageFormDAL();
        public IList GetList()
        {
            return dal.GetList();
        }

        public IList GetList(string pinyinCode)
        {
            string where = string.Empty;
            if (!string.IsNullOrEmpty(pinyinCode))
                where = " PinyinCode like '%" + pinyinCode + "%'";
            return dal.GetList(where);
        }
    }
}
