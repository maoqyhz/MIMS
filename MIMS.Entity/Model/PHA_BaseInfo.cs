using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PHA_BaseInfo
    public class PHA_BaseInfo
    {

        /// <summary>
        /// PhaCode
        /// </summary>		
        public string PhaCode { get; set; }
        /// <summary>
        /// PhaName
        /// </summary>		
        public string PhaName { get; set; }
        /// <summary>
        /// CommonName
        /// </summary>		
        public string CommonName { get; set; }
        /// <summary>
        /// Spec
        /// </summary>		
        public string Spec { get; set; }
        /// <summary>
        /// Unit
        /// </summary>		
        public string Unit { get; set; }
        /// <summary>
        /// DosageForm
        /// </summary>		
        public int DosageForm { get; set; }
        /// <summary>
        /// DosageForm(FK)
        /// </summary>		
        public string DosageName { get; set; }
        /// <summary>
        /// Repo
        /// </summary>		
        public string Repo { get; set; }
        /// <summary>
        /// Repo(FK)
        /// </summary>		
        public string RepoName { get; set; }
        /// <summary>
        /// IsSpecial
        /// </summary>		
        public int IsSpecial { get; set; }
        /// <summary>
        /// DispenseWay
        /// </summary>		
        public int DispenseWay { get; set; }
        /// <summary>
        /// DispenseWayName
        /// </summary>
        public string DispenseWayName { get; set; }
        /// <summary>
        /// PinyinCode
        /// </summary>		
        public string PinyinCode { get; set; }
        /// <summary>
        /// WubiCode
        /// </summary>		
        public string WubiCode { get; set; }
        /// <summary>
        /// IsAntibiotic
        /// </summary>		
        public int IsAntibiotic { get; set; }
        /// <summary>
        /// IsEmergency
        /// </summary>		
        public int IsEmergency { get; set; }
        /// <summary>
        /// IsValid
        /// </summary>		
        public int IsValid { get; set; }
        /// <summary>
        /// MinUnit
        /// </summary>		
        public string MinUnit { get; set; }
        /// <summary>
        /// PharmacySpec
        /// </summary>		
        public string PharmacySpec { get; set; }
        /// <summary>
        /// PharmacyUnit
        /// </summary>		
        public string PharmacyUnit { get; set; }
        /// <summary>
        /// PharmacyPack
        /// </summary>		
        public string PharmacyPack { get; set; }
        /// <summary>
        /// MinPack
        /// </summary>		
        public string MinPack { get; set; }
        /// <summary>
        /// WardSpec
        /// </summary>		
        public string WardSpec { get; set; }
        /// <summary>
        /// WardUnit
        /// </summary>		
        public string WardUnit { get; set; }
        /// <summary>
        /// WardPack
        /// </summary>		
        public string WardPack { get; set; }
        /// <summary>
        /// PhaAttr
        /// </summary>		
        public int PhaAttr { get; set; }
        /// <summary>
        /// PhaAttr(FK)
        /// </summary>		
        public string PhaAttrName { get; set; }
        /// <summary>
        /// StorageCondition
        /// </summary>		
        public int StorageCondition { get; set; }
        /// <summary>
        /// StorageConditionName
        /// </summary>
        public string StorageConditionName { get; set; }

    }
}

