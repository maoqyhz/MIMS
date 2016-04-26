using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PSS_InWarehouseDetail
    public class PSS_InWarehouseDetail
    {

        /// <summary>
        /// ID
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// IWID
        /// </summary>		
        public string IWID { get; set; }
        /// <summary>
        /// IWWay
        /// </summary>		
        public int IWWay { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// PhaCode
        /// </summary>		
        public string PhaCode { get; set; }
        /// <summary>
        /// OrginID
        /// </summary>		
        public int OrginID { get; set; }
        /// <summary>
        /// PhaNo
        /// </summary>		
        public string PhaNo { get; set; }
        /// <summary>
        /// PhaExpiry
        /// </summary>		
        public DateTime PhaExpiry { get; set; }
        /// <summary>
        /// InWarehouseCount
        /// </summary>		
        public double InWarehouseCount { get; set; }
        /// <summary>
        /// InWarehousePrice
        /// </summary>		
        public double InWarehousePrice { get; set; }
        /// <summary>
        /// InWarehouseSum
        /// </summary>		
        public double InWarehouseSum { get; set; }

        /// <summary>
        /// IWDate
        /// </summary>
        public string IWDate { get; set; }
    }
}

