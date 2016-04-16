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
    public class PHA_PhaAttrBLL : IPHA_PhaAttrBLL
    {
        private static readonly PHA_PhaAttrDAL dal = new PHA_PhaAttrDAL();
        public IList GetList()
        {
            return dal.GetList();
        }
    }
}
