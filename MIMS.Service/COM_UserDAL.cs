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
    public class COM_UserDAL
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
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public COM_User GetEntity(string id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM COM_User WHERE Username=@Username";
                return Conn.Query<COM_User>(query, new { Username = id }).SingleOrDefault();
            }
        }

        public int Update(COM_User obj)
        {
            using (Conn)
            {
                string query = @"UPDATE COM_User 
                                    SET  Code=@Code,Name=@Name,Username=@Username,Password=Password,
                                         Role=@Role,Tel=@Tel,Address=@Address,Department=@Department,IP=@IP
                                       WHERE Username =@Username";
                return Conn.Execute(query, obj);
            }
        }
        public int Insert(COM_User obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO COM_User 
                                    VALUES(@Code,@Name,@Username,@Password,@Role,@Tel,@Address,@Department,@IP)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(COM_User obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM COM_User WHERE Username = @Username";
                return Conn.Execute(query, obj);
            }
        }
    }
}
