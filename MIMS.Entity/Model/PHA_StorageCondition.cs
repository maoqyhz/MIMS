using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PHA_StorageCondition
    public class PHA_StorageCondition
    {

        /// <summary>
        /// StorageConditionId
        /// </summary>		
        public int StorageConditionID { get; set; }
        /// <summary>
        /// StorageConditionName
        /// </summary>		
        public string StorageConditionName { get; set; }
        /// <summary>
        /// PinyinCode
        /// </summary>
        public string PinyinCode { get; set; }

    }
}

