using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity
{
   /// <summary>
    /// 产地对照库
   /// </summary>
    public class MIMS_CDDZ
    {

        /// <summary>
        /// 药品产地
        /// </summary>		
        public double YPCD { get; set; }
        /// <summary>
        /// 产地名称
        /// </summary>		
        public string CDMC { get; set; }
        /// <summary>
        /// 拼音代码
        /// </summary>		
        public string PYDM { get; set; }
        /// <summary>
        /// 厂家全称
        /// </summary>		
        public string CDQC { get; set; }

    }
}

