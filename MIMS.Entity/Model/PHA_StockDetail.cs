using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PHA_StockDetail
    public class PHA_StockDetail
    {

        /// <summary>
        /// ID
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// PhaCode
        /// </summary>		
        public string PhaCode { get; set; }
        /// <summary>
        /// OrginID
        /// </summary>		
        public int OrginID { get; set; }
        /// <summary>
        /// LotNumber
        /// </summary>
        public string LotNumber { get; set; }
        /// <summary>
        /// Amount
        /// </summary>		
        public int Amount { get; set; }
        /// <summary>
        /// Property
        /// </summary>		
        public int Property { get; set; }
        /// <summary>
        /// InWarehousePrice
        /// </summary>		
        public double InWarehousePrice { get; set; }
        /// <summary>
        /// WholesalePrice
        /// </summary>		
        public double WholesalePrice { get; set; }
        /// <summary>
        /// RetailPrice
        /// </summary>		
        public double RetailPrice { get; set; }
        /// <summary>
        /// RetailSum
        /// </summary>		
        public double RetailSum { get; set; }
        /// <summary>
        /// WholesaleSum
        /// </summary>		
        public double WholesaleSum { get; set; }
        /// <summary>
        /// InWarehouseSum
        /// </summary>		
        public double InWarehouseSum { get; set; }

    }
}

