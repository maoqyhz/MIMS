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
        /// PhaName(FK)
        /// </summary>		
        public string PhaName { get; set; }
        /// <summary>
        /// PinyinCode(FK)
        /// </summary>		
        public string PinyinCode { get; set; }
        /// <summary>
        /// Spec(FK)
        /// </summary>		
        public string Spec { get; set; }
        /// <summary>
        /// Unit(FK)
        /// </summary>		
        public string Unit { get; set; }
        /// <summary>
        /// OrginID
        /// </summary>		
        public int OrginID { get; set; }
        /// <summary>
        /// OrginName(FK)
        /// </summary>		
        public string OrginName { get; set; }
        /// <summary>
        /// InWarehousePrice
        /// </summary>		
        public double InWarehousePrice { get; set; }
        /// <summary>
        /// InWarehouseSum
        /// </summary>
        public double InWarehouseSum { get; set; }
        /// <summary>
        /// Stock
        /// </summary>		
        public double Stock { get; set; }
        /// <summary>
        /// RetailSum
        /// </summary>		
        public double RetailSum { get; set; }
        /// <summary>
        /// WholesaleSum
        /// </summary>		
        public double WholesaleSum { get; set; }
        /// <summary>
        /// RetailPrice
        /// </summary>		
        public double RetailPrice { get; set; }
        /// <summary>
        /// WholesalePrice
        /// </summary>		
        public double WholesalePrice { get; set; }
        /// <summary>
        /// CompanyID
        /// </summary>		
        public int CompanyID { get; set; }
        /// <summary>
        /// CompanyName(FK)
        /// </summary>		
        public string CompanyName { get; set; }


    }
}

