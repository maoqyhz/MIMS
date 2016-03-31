using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.IBusiness;
using MIMS.Entity;
using MIMS.Service;

namespace MIMS.Business
{
    public class MIMS_TYPK_BLL:IMIMS_TYPK_BLL
    {
        private static readonly MIMS_TYPK_DAL dal = new MIMS_TYPK_DAL();
        public IList<MIMS_TYPK> GetList()
        {
            return dal.GetList();
        }
    }


}
