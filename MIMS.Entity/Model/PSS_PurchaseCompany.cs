using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PSS_PurchaseCompany
    public class PSS_PurchaseCompany
    {

        /// <summary>
        /// CompanyID
        /// </summary>		
        public int CompanyID { get; set; }
        /// <summary>
        /// CompanyName
        /// </summary>		
        public string CompanyName { get; set; }
        /// <summary>
        /// PinyinCode
        /// </summary>		
        public string PinyinCode { get; set; }
        /// <summary>
        /// Bank
        /// </summary>		
        public string Bank { get; set; }
        /// <summary>
        /// BankNo
        /// </summary>		
        public string BankNo { get; set; }
        /// <summary>
        /// Contact
        /// </summary>		
        public string Contact { get; set; }
        /// <summary>
        /// Tel
        /// </summary>		
        public string Tel { get; set; }
        /// <summary>
        /// Address
        /// </summary>		
        public string Address { get; set; }

    }
}

