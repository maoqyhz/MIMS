using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMS.Entity
{
    /// <summary>
    /// 药品编码设置
    /// </summary>
    public class MIMS_BMSZ
    {
        /// <summary>
        /// 识别序序
        /// </summary>
        public double SBXH { get; set; }
        /// <summary>
        /// 系统识别
        /// </summary>
        public double XTSB { get; set; }
        /// <summary>
        /// 编码名称
        /// </summary>		
        public string BMMC { get; set; }
        /// <summary>
        /// 编码长度
        /// </summary>		
        public double BMCD { get; set; }

    }
}
