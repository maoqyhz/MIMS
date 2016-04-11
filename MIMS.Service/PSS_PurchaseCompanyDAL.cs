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
    public class PSS_PurchaseCompanyDAL
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
                string query = "SELECT * FROM PSS_PurchaseCompany";
                return Conn.Query<PSS_PurchaseCompany>(query).ToList();
            }

        }
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PSS_PurchaseCompany GetEntity(string id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM PSS_PurchaseCompany WHERE CompanyID=@CompanyID";
                return Conn.Query<PSS_PurchaseCompany>(query, new { CompanyID = id }).SingleOrDefault();
            }
        }

        public int Update(PSS_PurchaseCompany obj)
        {
            using (Conn)
            {
                string query = @"UPDATE PSS_PurchaseCompany 
                                    SET  CompanyName=@CompanyName,PinyinCode=@PinyinCode,
                                         Bank=@Bank,BankNo=@BankNo,Contact=@Contact,Tel=@Tel,Address=@Address 
                                       WHERE CompanyID =@CompanyID";
                return Conn.Execute(query, obj);
            }
        }
        public int Insert(PSS_PurchaseCompany obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PSS_PurchaseCompany 
                                    VALUES(@CompanyName,@PinyinCode,@Bank,@BankNo,@Contact,@Tel,@Address)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PSS_PurchaseCompany obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PSS_PurchaseCompany WHERE CompanyID = @CompanyID";
                return Conn.Execute(query, obj);
            }
        }
    }
}
