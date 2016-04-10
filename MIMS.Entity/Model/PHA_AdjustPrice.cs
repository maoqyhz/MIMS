using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PHA_AdjustPrice
    public class PHA_AdjustPrice
    {

        /// <summary>
        /// APCode
        /// </summary>		
        public string APCode { get; set; }
        /// <summary>
        /// APWay
        /// </summary>		
        public string APWay { get; set; }
        /// <summary>
        /// ApDate
        /// </summary>		
        public DateTime ApDate { get; set; }
        /// <summary>
        /// APNum
        /// </summary>		
        public string APNum { get; set; }
        /// <summary>
        /// ExecDate
        /// </summary>		
        public DateTime ExecDate { get; set; }
        /// <summary>
        /// ExecNo
        /// </summary>		
        public string ExecNo { get; set; }

    }
}

