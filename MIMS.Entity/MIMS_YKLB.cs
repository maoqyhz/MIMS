using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity
{
    /// <summary>
    /// 药库列表
    /// </summary>
    public class MIMS_YKLB
    {

        /// <summary>
        /// 药库识别（系统识别)）
        /// </summary>		
        public double YKSB { get; set; }
        /// <summary>
        /// 药库名称
        /// </summary>		
        public string YKMC { get; set; }
        /// <summary>
        /// 药库类别
        /// </summary>		
        public double YKLB { get; set; }
        /// <summary>
        /// 使用标志
        /// </summary>		
        public double SYBZ { get; set; }

    }
}

