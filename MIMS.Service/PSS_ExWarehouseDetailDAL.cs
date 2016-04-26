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
    public class PSS_ExWarehouseDetailDAL
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
        /// <param name="prams"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IList GetList(Dictionary<string, object> prams, string where = null)
        {
            using (Conn)
            {
                string query = @"SELECT  * FROM(SELECT EW.*,M.Name,E.EWDate FROM PSS_ExWarehouseDetail EW
                                        LEFT JOIN PHA_Accounts A ON EW.PhaCode = A.PhaCode AND EW.OrginID = A.OrginID
                                        LEFT JOIN PSS_ExWarehouseMode M ON EW.EWWay = M.ID
                                        LEFT JOIN PSS_ExWarehouse E ON EW.EWID = E.EWID)A WHERE 1=1  ";
                if (!string.IsNullOrEmpty(where))
                    query += where;
                return Conn.Query<Dto_ExWarehouseDetail>(query, prams).ToList();
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
                sql.Append(@"SELECT * FROM (SELECT  E.*,
													B.PinyinCode,
													A.Stock,
													B.PhaName,
													B.Spec,
													B.Unit,
													O.OrginName,
													C.CompanyName
														FROM PSS_ExWarehouseDetail E
													LEFT JOIN PHA_Accounts A ON E.PhaCode = A.PhaCode AND E.OrginID = A.OrginID
													LEFT JOIN PHA_BaseInfo B ON E.PhaCode = B.PhaCode
													LEFT JOIN PHA_Orgin O ON E.OrginID = O.OrginID
													LEFT JOIN PSS_PurchaseCompany C ON A.CompanyID = C.CompanyID) A WHERE 1=1 ");
                sql.Append(where);
                strSql.Append("Select * From (Select ROW_NUMBER() Over (Order By " + orderField + " " + orderType + "");
                strSql.Append(") As rowNum, * From (" + sql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                count = Conn.Query<int>("Select Count(1) From (" + sql + ") As t", prams).Single();
                return Conn.Query<Dto_ExWarehouseDetail>(strSql.ToString(), prams).ToList();
            }
        }

        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PSS_ExWarehouseDetail GetEntity(string id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM PSS_ExWarehouseDetail WHERE ID=@ID";
                return Conn.Query<PSS_ExWarehouseDetail>(query, new { ID = id }).SingleOrDefault();
            }
        }

        //        public int Update(PSS_ExWarehouseDetail obj)
        //        {
        //            using (Conn)
        //            {
        //                string query = @"UPDATE PSS_ExWarehouseDetail 
        //                                    SET  PurchaseNo=@PurchaseNo,PurchaseDate=@PurchaseDate,
        //                                         Remark=@Remark,OperateNo=@OperateNo,OperateDate=@OperateDate,PurchaseStatus=@PurchaseStatus 
        //                                       WHERE PurchaseNo =@PurchaseNo";
        //                return Conn.Execute(query, obj);
        //            }
        //        }
        public int Insert(PSS_ExWarehouseDetail obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PSS_ExWarehouseDetail 
									VALUES(@EWID,@EWWay,@PhaCode,@OrginID,@ExWarehouseNum)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PSS_ExWarehouseDetail obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PSS_ExWarehouseDetail WHERE ID = @ID";
                return Conn.Execute(query, obj);
            }
        }

        /// <summary>
        /// 分页获取符合条件的入货药品记录
        /// </summary>
        /// <param name="where"></param>
        /// <param name="prams"></param>
        /// <param name="orderField"></param>
        /// <param name="orderType"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public IList SearchInDatePha(StringBuilder where, Dictionary<string, object> prams, string orderField, string orderType, int pageIndex, int pageSize, ref int count)
        {
            int num = (pageIndex - 1) * pageSize;
            int num1 = pageIndex * pageSize;
            using (Conn)
            {
                StringBuilder strSql = new StringBuilder();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"SELECT * FROM (SELECT EW.PhaCode,
                                                    EW.OrginID,
                                                    EW.ExWarehouseNum,
                                                    E.EWDate,
                                                    B.PhaName,
                                                    B.Spec,
                                                    B.Unit,
                                                    B.PinyinCode,
                                                    O.OrginName
                                                     FROM PSS_ExWarehouseDetail EW
                                                    LEFT JOIN PHA_BaseInfo B ON EW.PhaCode = B.PhaCode
                                                    LEFT JOIN PHA_Orgin O ON EW.OrginID = O.OrginID
                                                    LEFT JOIN PSS_ExWarehouse E ON EW.EWID = E.EWID) A WHERE 1=1 ");
                sql.Append(where);
                strSql.Append("Select * From (Select ROW_NUMBER() Over (Order By " + orderField + " " + orderType + "");
                strSql.Append(") As rowNum, * From (" + sql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                count = Conn.Query<int>("Select Count(1) From (" + sql + ") As t", prams).Single();
                return Conn.Query<Dto_ExWarehouseDetail>(strSql.ToString(), prams).ToList();
            }
        }

    }
}
