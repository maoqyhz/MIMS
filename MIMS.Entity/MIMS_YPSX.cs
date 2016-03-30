using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity
{
    /// <summary>
    /// 药品属性库表
    /// </summary>
    public class MIMS_YPSX
    {

        /// <summary>
        /// 药品属性
        /// </summary>		
        public double YPSX { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>		
        public string SXMC { get; set; }
        /// <summary>
        /// 拼音代码
        /// </summary>		
        public string PYDM { get; set; }
        /// <summary>
        /// 系统识别
        /// </summary>		
        public double XTSB { get; set; }

    }
}

