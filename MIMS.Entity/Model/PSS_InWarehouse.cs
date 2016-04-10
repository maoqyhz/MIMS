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
        public int IWID { get; set; }
        /// <summary>
        /// IWWay
        /// </summary>		
        public int IWWay { get; set; }
        /// <summary>
        /// companyID
        /// </summary>		
        public int companyID { get; set; }
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
        /// PurchaseDate
        /// </summary>		
        public DateTime PurchaseDate { get; set; }
        /// <summary>
        /// IWDate
        /// </summary>		
        public DateTime IWDate { get; set; }
        /// <summary>
        /// PurchaseNo
        /// </summary>		
        public string PurchaseNo { get; set; }
        /// <summary>
        /// OperateNo
        /// </summary>		
        public string OperateNo { get; set; }

    }
}

