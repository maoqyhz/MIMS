using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PSS_InWarehouse
    public class PSS_InWarehouse
    {

        /// <summary>
        /// IWID
        /// </summary>		
        public string IWID { get; set; }
        /// <summary>
        /// IWWay
        /// </summary>		
        public int IWWay { get; set; }
        /// <summary>
        /// Name(FK)
        /// </summary>		
        public string Name { get; set; }

        /// <summary>
        /// companyID
        /// </summary>		
        public int CompanyID { get; set; }
        /// <summary>
        /// companyName(FK)
        /// </summary>		
        public string CompanyName { get; set; }
        /// <summary>
        /// Receipts
        /// </summary>		
        public int Receipts { get; set; }
        /// <summary>
        /// IWRemark
        /// </summary>		
        public string IWRemark { get; set; }
        /// <summary>
        /// IsIW
        /// </summary>		
        public int IsIW { get; set; }

        /// <summary>
        /// IWDate
        /// </summary>		
        public string IWDate { get; set; }
        /// <summary>
        /// OperateNo
        /// </summary>		
        public string OperateNo { get; set; }
        /// <summary>
        /// OperateDate
        /// </summary>		
        public string OperateDate { get; set; }

    }
}

