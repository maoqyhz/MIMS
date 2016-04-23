using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIMS.Entity.Dtos
{
    public class Dto_PurchasePlanDetail
    {
        /// <summary>
        /// 编号
        /// </summary>		
        public int ID { get; set; }
        /// <summary>
        /// 采购单号
        /// </summary>		
        public string PurchaseNo { get; set; }
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
        /// 采购价格
        /// </summary>		
        public double InWarehousePrice { get; set; }
        /// <summary>
        /// 采购数量
        /// </summary>		
        public double PurchaseNum { get; set; }
        /// <summary>
        /// 采购总金额
        /// </summary>
        public double InWarehouseSum { get; set; }
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
