using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity
{
    /// <summary>
    /// 药品编码字典
    /// </summary>
    public class MIMS_BMZD
    {

        /// <summary>
        /// 识别序号
        /// </summary>		
        public double SBXH { get; set; }
        /// <summary>
        /// 编码序号
        /// </summary>		
        public string BMXH { get; set; }
        /// <summary>
        /// 系统识别
        /// </summary>		
        public double XTSB { get; set; }
        /// <summary>
        /// 编码名称
        /// </summary>		
        public string BMMC { get; set; }

    }
}

