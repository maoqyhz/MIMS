using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MIMS.Entity.Model
{
    //PHA_Repository
    public class PHA_Repository
    {

        /// <summary>
        /// RepoID
        /// </summary>		
        public string RepoID { get; set; }
        /// <summary>
        /// RepoName
        /// </summary>		
        public string RepoName { get; set; }
        /// <summary>
        /// PhaNum
        /// </summary>		
        public int PhaNum { get; set; }
        /// <summary>
        /// IsValid
        /// </summary>		
        public int IsValid { get; set; }
        /// <summary>
        /// PinyinCode
        /// </summary>
        public string PinyinCode { get; set; }

    }
}

