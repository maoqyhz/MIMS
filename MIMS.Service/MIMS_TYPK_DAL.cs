using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MIMS.Entity;
using System.Collections;


namespace MIMS.Service
{
    public class MIMS_TYPK_DAL
    {
        #region init dbconnection
        private static readonly string connString = ConfigurationManager.ConnectionStrings["MIMS"].ConnectionString;
        private IDbConnection _conn;
        public IDbConnection Conn
        {
            get
            {
                _conn = new SqlConnection(connString);
                _conn.Open();
                return _conn;
            }
        }
        #endregion

        public IList<MIMS_TYPK> GetList()
        {
            using (Conn)
            {
                string query = "SELECT top 20 * FROM MIMS_TYPK";
                return Conn.Query<MIMS_TYPK>(query).ToList();
            }

        }
        /// <summary>
        /// 分页获取数据列表(带条件)
        /// </summary>
        /// <param name="where">条件</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="prams">参数</param>
        /// <param name="orderType">排序类型</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">总条数</param>
        /// <returns></returns>
        public IList GetPageListWhere(StringBuilder where, Dictionary<string,object> prams, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            int num = (pageIndex - 1) * pageSize;
            int num1 = pageIndex * pageSize;
            using (Conn)
            {
                StringBuilder strSql = new StringBuilder();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"SELECT * FROM (SELECT     T.YPXH,
                                        T.YPMC,
                                        T.YPGG,
                                        T.YPDW,
                                        Y.SXMC,
                                        T.PYDM,
                                        T.YPDM,
                                        T.TSYP,
                                        T.WBDM,
                                        T.JXDM
                               FROM MIMS_TYPK T 
                                        LEFT JOIN MIMS_YPSX Y ON T.YPSX = Y.YPSX) A WHERE 1=1 ");
                sql.Append(where);
                strSql.Append("Select * From (Select ROW_NUMBER() Over (Order By " + orderField + " " + orderType + "");
                strSql.Append(") As rowNum, * From (" + sql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                count = Conn.Query<int>("Select Count(1) From (" + sql + ") As t", prams).Single();
                return Conn.Query<MIMS_TYPK>(strSql.ToString(), prams).ToList();
            }

        }
    }
}
