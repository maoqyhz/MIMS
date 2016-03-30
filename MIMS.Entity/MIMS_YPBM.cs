using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity
{
    /// <summary>
    /// 药品别名库表
    /// </summary>
    public class MIMS_YPBM
    {

        /// <summary>
        /// 药品序号
        /// </summary>		
        public double YPXH { get; set; }
        /// <summary>
        /// 拼音代码
        /// </summary>		
        public string PYDM { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>		
        public string YPMC { get; set; }
        /// <summary>
        /// 编码分类
        /// </summary>		
        public double BMFL { get; set; }

    }
}

