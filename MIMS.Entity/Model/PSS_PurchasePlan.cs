using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PSS_PurchasePlan
    public class PSS_PurchasePlan
    {

        /// <summary>
        /// PurchaseNo
        /// </summary>		
        public string PurchaseNo { get; set; }
        /// <summary>
        /// PurchaseDate
        /// </summary>		
        public string PurchaseDate { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// OperateNo
        /// </summary>		
        public string OperateNo { get; set; }
        /// <summary>
        /// OperateDate
        /// </summary>		
        public string OperateDate { get; set; }
        /// <summary>
        /// PurchaseStatus
        /// </summary>		
        public int PurchaseStatus { get; set; }

    }
}

