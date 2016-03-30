using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity
{
    /// <summary>
    /// 帐薄类别
    /// </summary>
    public class MIMS_ZBLB
    {

        /// <summary>
        /// 帐薄序号
        /// </summary>		
        public double ZBXH { get; set; }
        /// <summary>
        /// 帐薄名称
        /// </summary>		
        public string ZBMC { get; set; }
        /// <summary>
        /// 收费项目
        /// </summary>		
        public double SFXM { get; set; }

    }
}

