using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PHA_Accounts
    public class PHA_Accounts
    {

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
        /// Stock
        /// </summary>		
        public int Stock { get; set; }
        /// <summary>
        /// RetailSum
        /// </summary>		
        public decimal RetailSum { get; set; }
        /// <summary>
        /// WholesaleSum
        /// </summary>		
        public decimal WholesaleSum { get; set; }
        /// <summary>
        /// RetailPrice
        /// </summary>		
        public decimal RetailPrice { get; set; }
        /// <summary>
        /// WholesalePrice
        /// </summary>		
        public decimal WholesalePrice { get; set; }
        /// <summary>
        /// CompanyID
        /// </summary>		
        public int CompanyID { get; set; }

    }
}

