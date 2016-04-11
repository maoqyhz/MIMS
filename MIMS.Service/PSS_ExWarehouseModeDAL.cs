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
    public class PSS_ExWarehouseModeDAL
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
                string query = "SELECT * FROM PSS_ExWarehouseMode";
                return Conn.Query<PSS_ExWarehouseMode>(query).ToList();
            }

        }
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PSS_ExWarehouseMode GetEntity(string id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM PSS_ExWarehouseMode WHERE ID=@ID";
                return Conn.Query<PSS_ExWarehouseMode>(query, new { ID = id }).SingleOrDefault();
            }
        }

        public int Update(PSS_ExWarehouseMode obj)
        {
            using (Conn)
            {
                string query = @"UPDATE PSS_ExWarehouseMode 
                                    SET  Name=@Name,Way=@Way WHERE ID =@ID";
                return Conn.Execute(query, obj);
            }
        }
        public int Insert(PSS_ExWarehouseMode obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PSS_ExWarehouseMode 
                                    VALUES(@Name,@Way)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PSS_ExWarehouseMode obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PSS_ExWarehouseMode 
                                   WHERE ID = @ID";
                return Conn.Execute(query, obj);
            }
        }
    }
}
