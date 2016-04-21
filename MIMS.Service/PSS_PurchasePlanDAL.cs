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
    public class PSS_PurchasePlanDAL
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
                string query = "SELECT * FROM PSS_PurchasePlan";
                return Conn.Query<PSS_PurchasePlan>(query).ToList();
            }

        }
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PSS_PurchasePlan GetEntity(string id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM PSS_PurchasePlan WHERE PurchaseNo=@PurchaseNo";
                return Conn.Query<PSS_PurchasePlan>(query, new { PurchaseNo = id }).SingleOrDefault();
            }
        }

        public int Update(PSS_PurchasePlan obj)
        {
            using (Conn)
            {
                string query = @"UPDATE PSS_PurchasePlan 
                                    SET  PurchaseNo=@PurchaseNo,PurchaseDate=@PurchaseDate,
                                         Remark=@Bank,OperateNo=@OperateNo,OperateDate=@OperateDate,PurchaseStatus=@PurchaseStatus 
                                       WHERE PurchaseNo =@PurchaseNo";
                return Conn.Execute(query, obj);
            }
        }
        public int Insert(PSS_PurchasePlan obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PSS_PurchasePlan 
                                    VALUES(@PurchaseNo,@PurchaseDate,@Remark,@OperateNo,@OperateDate,@PurchaseStatus)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PSS_PurchasePlan obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PSS_PurchasePlan WHERE PurchaseNo = @PurchaseNo";
                return Conn.Execute(query, obj);
            }
        }
    }
}
