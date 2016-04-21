using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIMS.Entity.Model;
using MIMS.IBusiness;
using MIMS.Service;

namespace MIMS.Business
{
    public class COM_UserBLL : ICOM_UserBLL
    {
        private static readonly COM_UserDAL dal = new COM_UserDAL();
        public COM_User GetEntity(string id)
        {
            return dal.GetEntity(id);
        }

        public int Update(COM_User obj)
        {
            return dal.Update(obj);
        }

        public int Insert(COM_User obj)
        {
            return dal.Insert(obj);
        }

        public int Delete(COM_User obj)
        {
            return dal.Delete(obj);
        }
    }
}
