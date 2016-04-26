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
    public class PSS_ExWarehouseDAL
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
                string query = @"SELECT  E.*,
                                        M.Name
                                        FROM PSS_ExWarehouse E
                                        LEFT JOIN PSS_ExWarehouseMode M ON E.EWWay = M.ID";
                return Conn.Query<PSS_ExWarehouse>(query).ToList();
            }

        }
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PSS_ExWarehouse GetEntity(string id)
        {
            using (Conn)
            {
                string query = @"SELECT  E.*,
                                        M.Name
                                        FROM PSS_ExWarehouse E
                                        LEFT JOIN PSS_ExWarehouseMode M ON E.EWWay = M.ID
                                        WHERE EWID=@EWID";
                return Conn.Query<PSS_ExWarehouse>(query, new { EWID = id }).SingleOrDefault();
            }
        }

        public int Update(PSS_ExWarehouse obj)
        {
            using (Conn)
            {
                string query = @"UPDATE PSS_ExWarehouse 
                                    SET EWID=@EWID,EWWay=@EWWay,Remark=@Remark,IsEW=@IsEW,
                                         EWDate=@EWDate,OperateNo=@OperateNo,OperateDate=@OperateDate 
                                       WHERE EWID =@EWID";
                return Conn.Execute(query, obj);
            }
        }
        public int Insert(PSS_ExWarehouse obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PSS_ExWarehouse 
                                    VALUES(@EWID,@EWWay,@Remark,@EWDate,@OperateNo,@OperateDate,@IsEW)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PSS_ExWarehouse obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PSS_ExWarehouse WHERE EWID = @EWID";
                return Conn.Execute(query, obj);
            }
        }
    }
}
