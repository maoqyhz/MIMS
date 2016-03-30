using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity
{
   /// <summary>
   /// 药品基本库表
   /// </summary>
    public class MIMS_TYPK
    {

        /// <summary>
        /// 药品序号
        /// </summary>		
        public double YPXH { get; set; }
        /// <summary>
        /// 系统识别
        /// </summary>		
        public double XTSB { get; set; }
        /// <summary>
        /// 药品名称
        /// </summary>		
        public string YPMC { get; set; }
        /// <summary>
        /// 药品规格
        /// </summary>		
        public string YPGG { get; set; }
        /// <summary>
        /// 药房规格
        /// </summary>		
        public string YFGG { get; set; }
        /// <summary>
        /// 病房规格
        /// </summary>		
        public string BFGG { get; set; }
        /// <summary>
        /// 药品属性
        /// </summary>		
        public double YPSX { get; set; }
        /// <summary>
        /// 特殊药品
        /// </summary>		
        public double TSYP { get; set; }
        /// <summary>
        /// 药品单位
        /// </summary>		
        public string YPDW { get; set; }
        /// <summary>
        /// 最小单位
        /// </summary>		
        public string ZXDW { get; set; }
        /// <summary>
        /// 最小包装
        /// </summary>		
        public double ZXBZ { get; set; }
        /// <summary>
        /// 药房包装
        /// </summary>		
        public double YFBZ { get; set; }
        /// <summary>
        /// 药房单位
        /// </summary>		
        public string YFDW { get; set; }
        /// <summary>
        /// 病房包装
        /// </summary>		
        public double BFBZ { get; set; }
        /// <summary>
        /// 病房单位
        /// </summary>		
        public string BFDW { get; set; }
        /// <summary>
        /// 作废判别
        /// </summary>		
        public double ZFPB { get; set; }
        /// <summary>
        /// 注射收费
        /// </summary>		
        public double ZSSF { get; set; }
        /// <summary>
        /// 皮试判别
        /// </summary>		
        public double PSPB { get; set; }
        /// <summary>
        /// 用量限制
        /// </summary>		
        public double YLXZ { get; set; }
        /// <summary>
        /// 发药方式
        /// </summary>		
        public double FYFS { get; set; }
        /// <summary>
        /// 拼音代码
        /// </summary>		
        public string PYDM { get; set; }
        /// <summary>
        /// 五笔代码
        /// </summary>		
        public string WBDM { get; set; }
        /// <summary>
        /// 角形代码
        /// </summary>		
        public string JXDM { get; set; }
        /// <summary>
        /// 其他代码
        /// </summary>		
        public string QTDM { get; set; }
        /// <summary>
        /// 高储数量
        /// </summary>		
        public double GCSL { get; set; }
        /// <summary>
        /// 低储数量
        /// </summary>		
        public double DCSL { get; set; }
        /// <summary>
        /// 药品编号
        /// </summary>		
        public string YPBH { get; set; }
        /// <summary>
        /// 药品说明
        /// </summary>		
        public string MESS { get; set; }
        /// <summary>
        /// 定价级别
        /// </summary>		
        public int DJJB { get; set; }
        /// <summary>
        /// 库位编码
        /// </summary>		
        public string KWBM { get; set; }
        /// <summary>
        /// 药品效期
        /// </summary>		
        public double YPXQ { get; set; }
        /// <summary>
        /// 给药方法
        /// </summary>		
        public double GYFF { get; set; }
        /// <summary>
        /// 药品类别
        /// </summary>		
        public double TYPE { get; set; }
        /// <summary>
        /// 药品编码
        /// </summary>		
        public string YPDM { get; set; }
        /// <summary>
        /// 药品档次
        /// </summary>		
        public double YPDC { get; set; }
        /// <summary>
        /// 药房低储
        /// </summary>		
        public double YFDC { get; set; }
        /// <summary>
        /// 病房低储
        /// </summary>		
        public double BFDC { get; set; }
        /// <summary>
        /// 药库作废
        /// </summary>		
        public double YKZF { get; set; }
        /// <summary>
        /// 药房作废
        /// </summary>		
        public double YFZF { get; set; }
        /// <summary>
        /// 病房作废
        /// </summary>		
        public double BFZF { get; set; }
        /// <summary>
        /// 制剂判别
        /// </summary>		
        public double ZJPB { get; set; }
        /// <summary>
        /// 急诊用药
        /// </summary>		
        public double JZYY { get; set; }
        /// <summary>
        /// 药品剂量
        /// </summary>		
        public double YPJL { get; set; }
        /// <summary>
        /// 剂量单位
        /// </summary>		
        public string JLDW { get; set; }
        /// <summary>
        /// 帐薄类别
        /// </summary>		
        public double ZBLB { get; set; }
        /// <summary>
        /// ABC类别
        /// </summary>		
        public string ABC { get; set; }
        /// <summary>
        /// 药房高储
        /// </summary>		
        public double YFGC { get; set; }
        /// <summary>
        /// 病房高储
        /// </summary>		
        public double BFGC { get; set; }
        /// <summary>
        /// 取整策略
        /// </summary>		
        public double QZCL { get; set; }
        /// <summary>
        /// TPN
        /// </summary>		
        public double TPN { get; set; }
        /// <summary>
        /// 自选产地
        /// </summary>		
        public double ZXCD { get; set; }
        /// <summary>
        /// 抗生素标志
        /// </summary>		
        public double KSBZ { get; set; }
        /// <summary>
        /// 一次用量
        /// </summary>		
        public double YCYL { get; set; }

    }
}

