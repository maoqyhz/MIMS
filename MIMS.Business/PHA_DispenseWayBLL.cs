using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.IBusiness;
using System.Collections;
using MIMS.Service;

namespace MIMS.Business
{
    public class PHA_DispenseWayBLL:IPHA_DispenseWayBLL
    {
        private static readonly PHA_DispenseWayDAL dal = new PHA_DispenseWayDAL();
        public IList GetList()
        {
            return dal.GetList();
        }
    }
}
