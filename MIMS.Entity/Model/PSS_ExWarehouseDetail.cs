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
        /// ExWarehouseNum
        /// </summary>		
        public double ExWarehouseNum { get; set; }

    }
}

