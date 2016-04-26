using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMS.Entity.Dtos
{
    public class Dto_ExWarehouseDetail
    {
        /// <summary>
        /// 编号
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// 入库单号
        /// </summary>		
        public string EWID { get; set; }
        /// <summary>
        /// 入库方式
        /// </summary>
        public int EWWay { get; set; }
        /// <summary>
        /// 入库方式名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 药品编号
        /// </summary>		
        public string PhaCode { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>
        public string PhaName { get; set; }
        /// <summary>
        /// 规格
        /// </summary>
        public string Spec { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// 拼音代码
        /// </summary>
        public string PinyinCode { get; set; }
        /// <summary>
        /// 产地编号
        /// </summary>		
        public int OrginID { get; set; }
        /// <summary>
        /// 产地名称
        /// </summary>		
        public string OrginName { get; set; }
        /// <summary>
        /// 出库数量
        /// </summary>		
        public double ExWarehouseNum { get; set; }
        /// <summary>
        /// 现有库存
        /// </summary>		
        public double Stock { get; set; }
        /// <summary>
        /// 入货单位编号
        /// </summary>		
        public int CompanyID { get; set; }
        /// <summary>
        /// 入货单位名称
        /// </summary>		
        public string CompanyName { get; set; }
    }
}
