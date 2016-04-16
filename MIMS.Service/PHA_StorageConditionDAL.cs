using MIMS.Entity.Model;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace MIMS.Service
{
    public class PHA_StorageConditionDAL
    {
        #region init dbconnection
        private static readonly string connString = ConfigurationManager.ConnectionStrings["PharmacySystem"].ConnectionString;
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

        /// <summary>
        /// 获取一个list的数据
        /// </summary>
        /// <returns></returns>
        public IList GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM PHA_StorageCondition";
                return Conn.Query<PHA_StorageCondition>(query).ToList();
            }

        }
        /// <summary>
        /// 根据条件获得列表
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList GetList(string where)
        {
            using (Conn)
            {
                string query = "SELECT * FROM PHA_StorageCondition WHERE 1=1 AND";
                query += where;
                return Conn.Query<PHA_StorageCondition>(query).ToList();
            }

        }
    }
}
