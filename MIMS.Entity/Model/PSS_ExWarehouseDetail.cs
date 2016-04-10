using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PSS_ExWarehouseDetail
    public class PSS_ExWarehouseDetail
    {

        /// <summary>
        /// ID
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// EWID
        /// </summary>		
        public string EWID { get; set; }
        /// <summary>
        /// EWWay
        /// </summary>		
        public int EWWay { get; set; }
        /// <summary>
        /// PhaCode
        /// </summary>		
        public string PhaCode { get; set; }
        /// <summary>
        /// OrginID
        /// </summary>		
        public int OrginID { get; set; }
        /// <summary>
        /// InWarehousePrice
        /// </summary>		
        public decimal InWarehousePrice { get; set; }
        /// <summary>
        /// WholesalePrice
        /// </summary>		
        public decimal WholesalePrice { get; set; }
        /// <summary>
        /// RetailPrice
        /// </summary>		
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// ApplyNum
        /// </summary>		
        public int ApplyNum { get; set; }
        /// <summary>
        /// RealNum
        /// </summary>		
        public int RealNum { get; set; }

    }
}

