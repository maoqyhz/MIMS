using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PHA_AdjustPriceDetail
    public class PHA_AdjustPriceDetail
    {

        /// <summary>
        /// ID
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// APCode
        /// </summary>		
        public string APCode { get; set; }
        /// <summary>
        /// APWay
        /// </summary>		
        public string APWay { get; set; }
        /// <summary>
        /// PhaCode
        /// </summary>		
        public string PhaCode { get; set; }
        /// <summary>
        /// OrginID
        /// </summary>		
        public int OrginID { get; set; }
        /// <summary>
        /// NewRetailPrice
        /// </summary>		
        public double NewRetailPrice { get; set; }
        /// <summary>
        /// OldRetailPrice
        /// </summary>		
        public double OldRetailPrice { get; set; }
        /// <summary>
        /// NewWholesalePrice
        /// </summary>		
        public double NewWholesalePrice { get; set; }
        /// <summary>
        /// OldWholesalePrice
        /// </summary>		
        public double OldWholesalePrice { get; set; }
        /// <summary>
        /// RetailFloat
        /// </summary>		
        public double RetailFloat { get; set; }
        /// <summary>
        /// WholesaleFloat
        /// </summary>		
        public double WholesaleFloat { get; set; }

    }
}

