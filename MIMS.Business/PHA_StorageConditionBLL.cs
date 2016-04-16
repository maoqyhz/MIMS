using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MIMS.IBusiness;
using MIMS.Service;

namespace MIMS.Business
{
    public class PHA_StorageConditionBLL : IPHA_StorageConditionBLL
    {
        private static readonly PHA_StorageConditionDAL dal = new PHA_StorageConditionDAL();
        public IList GetList()
        {
            return dal.GetList();
        }
    }
}
