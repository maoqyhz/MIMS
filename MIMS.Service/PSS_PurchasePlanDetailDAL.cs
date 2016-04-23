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
using MIMS.Entity.Dtos;

namespace MIMS.Service
{
    public class PSS_PurchasePlanDetailDAL
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
                string query = "SELECT * FROM PSS_PurchasePlanDetail";
                return Conn.Query<PSS_PurchasePlanDetail>(query).ToList();
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
        public IList GetPageListWhere(StringBuilder where, Dictionary<string, object> prams, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            int num = (pageIndex - 1) * pageSize;
            int num1 = pageIndex * pageSize;
            using (Conn)
            {
                StringBuilder strSql = new StringBuilder();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"SELECT * FROM (SELECT 
                                                    B.PinyinCode,
                                                    P.PhaCode,
                                                    P.OrginID,
                                                    P.ID,
                                                    P.PurchaseNum,
                                                    P.PurchaseNo,
                                                    A.InWarehousePrice,
                                                    A.WholesalePrice,
                                                    A.RetailPrice,
                                                    A.Stock,
                                                    B.PhaName,
                                                    B.Spec,
                                                    B.Unit,
                                                    O.OrginName,
                                                    C.CompanyName
                                                     FROM PSS_PurchasePlanDetail P
                                                    LEFT JOIN PHA_Accounts A ON P.PhaCode = A.PhaCode AND P.OrginID = A.OrginID
                                                    LEFT JOIN PHA_BaseInfo B ON P.PhaCode = B.PhaCode
                                                    LEFT JOIN PHA_Orgin O ON P.OrginID = O.OrginID
                                                    LEFT JOIN PSS_PurchaseCompany C ON A.CompanyID = C.CompanyID) A WHERE 1=1 ");
                sql.Append(where);
                strSql.Append("Select * From (Select ROW_NUMBER() Over (Order By " + orderField + " " + orderType + "");
                strSql.Append(") As rowNum, * From (" + sql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                count = Conn.Query<int>("Select Count(1) From (" + sql + ") As t", prams).Single();
                return Conn.Query<Dto_PurchasePlanDetail>(strSql.ToString(), prams).ToList();
            }
        }

        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PSS_PurchasePlanDetail GetEntity(string id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM PSS_PurchasePlanDetail WHERE ID=@ID";
                return Conn.Query<PSS_PurchasePlanDetail>(query, new { ID = id }).SingleOrDefault();
            }
        }

//        public int Update(PSS_PurchasePlanDetail obj)
//        {
//            using (Conn)
//            {
//                string query = @"UPDATE PSS_PurchasePlanDetail 
//                                    SET  PurchaseNo=@PurchaseNo,PurchaseDate=@PurchaseDate,
//                                         Remark=@Remark,OperateNo=@OperateNo,OperateDate=@OperateDate,PurchaseStatus=@PurchaseStatus 
//                                       WHERE PurchaseNo =@PurchaseNo";
//                return Conn.Execute(query, obj);
//            }
//        }
        public int Insert(PSS_PurchasePlanDetail obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PSS_PurchasePlanDetail 
                                    VALUES(@PurchaseNo,@PhaCode,@OrginID,@PurchaseNum)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PSS_PurchasePlanDetail obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PSS_PurchasePlanDetail WHERE ID = @ID";
                return Conn.Execute(query, obj);
            }
        }
    }
}
