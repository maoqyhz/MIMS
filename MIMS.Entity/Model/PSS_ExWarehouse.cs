using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PSS_ExWarehouse
    public class PSS_ExWarehouse
    {

        /// <summary>
        /// EWID
        /// </summary>		
        public string EWID { get; set; }
        /// <summary>
        /// EWWay
        /// </summary>		
        public int EWWay { get; set; }
        /// <summary>
        /// EWWayName(FK)
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// IsEW
        /// </summary>
        /// <returns></returns>
        public int IsEW { get; set; }
        /// <summary>
        /// Remark
        /// </summary>		
        public string Remark { get; set; }
        /// <summary>
        /// EWDate
        /// </summary>		
        public string EWDate { get; set; }
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

