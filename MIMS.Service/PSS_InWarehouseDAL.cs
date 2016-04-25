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
    public class PSS_InWarehouseDAL
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
                string query = @"SELECT  I.*,
                                        M.Name,
                                        C.CompanyName
                                        FROM PSS_InWarehouse I
                                        LEFT JOIN PSS_InWarehouseMode M ON I.IWWay = M.ID
                                        LEFT JOIN PSS_PurchaseCompany C ON I.CompanyID = C.CompanyID";
                return Conn.Query<PSS_InWarehouse>(query).ToList();
            }

        }
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PSS_InWarehouse GetEntity(string id)
        {
            using (Conn)
            {
                string query = @"SELECT  I.*,
                                        M.Name,
                                        C.CompanyName
                                        FROM PSS_InWarehouse I
                                        LEFT JOIN PSS_InWarehouseMode M ON I.IWWay = M.ID
                                        LEFT JOIN PSS_PurchaseCompany C ON I.CompanyID = C.CompanyID 
                                        WHERE IWID=@IWID";
                return Conn.Query<PSS_InWarehouse>(query, new { IWID = id }).SingleOrDefault();
            }
        }

        public int Update(PSS_InWarehouse obj)
        {
            using (Conn)
            {
                string query = @"UPDATE PSS_InWarehouse 
                                    SET IWID=@IWID,IWWay=@IWWay,CompanyID=@CompanyID,
                                         Receipts=@Receipts,IWRemark=@IWRemark,IsIW=@IsIW,
                                         IWDate=@IWDate,OperateNo=@OperateNo,OperateDate=@OperateDate 
                                       WHERE IWID =@IWID";
                return Conn.Execute(query, obj);
            }
        }
        public int Insert(PSS_InWarehouse obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PSS_InWarehouse 
                                    VALUES(@IWID,@IWWay,@CompanyID,@Receipts,@IWRemark,@IsIW,@IWDate,@OperateNo,@OperateDate)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PSS_InWarehouse obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PSS_InWarehouse WHERE IWID = @IWID";
                return Conn.Execute(query, obj);
            }
        }
    }
}
