using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MIMS.Entity.Model;

namespace MIMS.Service
{
    public class PHA_BaseInfoDAL
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


        public IList<PHA_BaseInfo> GetList()
        {
            using (Conn)
            {
                string query = "SELECT top 100 * FROM PHA_BaseInfo";
                return Conn.Query<PHA_BaseInfo>(query).ToList();
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
                sql.Append(@"SELECT * FROM (SELECT  B.PhaCode,
                                                    B.PhaName,
                                                    B.Spec,
                                                    B.Unit,
                                                    D.DosageName,
                                                    B.IsSpecial,
                                                    R.RepoName,
                                                    P.PhaAttrName,
                                                    B.PinyinCode,
                                                    B.WubiCode
                                                FROM PHA_BaseInfo B 
                                                    LEFT JOIN PHA_DosageForm D  ON B.DosageForm = D.DosageID 
                                                    LEFT JOIN PHA_Repository R ON B.Repo = R.RepoID
                                                    LEFT JOIN PHA_PhaAttr P ON B.PhaAttr = P.PhaAttrID) A WHERE 1=1 ");
                sql.Append(where);
                strSql.Append("Select * From (Select ROW_NUMBER() Over (Order By " + orderField + " " + orderType + "");
                strSql.Append(") As rowNum, * From (" + sql + ") As T ) As N Where rowNum > " + num + " And rowNum <= " + num1 + "");
                count = Conn.Query<int>("Select Count(1) From (" + sql + ") As t", prams).Single();
                return Conn.Query<PHA_BaseInfo>(strSql.ToString(), prams).ToList();
            }

        }
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PHA_BaseInfo GetEntity(string id)
        {
            using (Conn)
            {
                string query = @"SELECT B.*,
                                        D.DosageName,
                                        R.RepoName,
                                        DW.DispenseWayName,
                                        P.PhaAttrName,
                                        S.StorageConditionName
                                         FROM PHA_BaseInfo B
                                        LEFT JOIN PHA_DosageForm D ON B.DosageForm = D.DosageID
                                        LEFT JOIN PHA_Repository R ON B.Repo = R.RepoID
                                        LEFT JOIN PHA_DispenseWay DW ON B.DispenseWay = DW.DispenseWayID
                                        LEFT JOIN PHA_PhaAttr P ON B.PhaAttr = P.PhaAttrID
                                        LEFT JOIN PHA_StorageCondition S ON B.StorageCondition = S.StorageConditionId
                                        WHERE PhaCode = @PhaCode";
                return Conn.Query<PHA_BaseInfo>(query, new { PhaCode = id }).SingleOrDefault();
            }
        }

        public int Update(PHA_BaseInfo obj)
        {
            using (Conn)
            {
                string query = @"UPDATE PHA_BaseInfo SET 
                                                            PhaName=@PhaName,
                                                            CommonName=@CommonName,
                                                            Spec=@Spec,
                                                            Unit=@Unit,
                                                            DosageForm=@DosageForm,
                                                            Repo=@Repo,
                                                            IsSpecial=@IsSpecial,
                                                            DispenseWay=@DispenseWay,
                                                            PinyinCode=@PinyinCode,
                                                            WubiCode=@WubiCode,
                                                            IsAntibiotic=@IsAntibiotic,
                                                            IsEmergency=@IsEmergency,
                                                            IsValid=@IsValid,
                                                            MinUnit=@MinUnit,
                                                            PharmacySpec=@PharmacySpec,
                                                            PharmacyUnit=@PharmacyUnit,
                                                            PharmacyPack=@PharmacyPack,
                                                            MinPack=@MinPack,
                                                            WardSpec=@WardSpec,
                                                            WardUnit=@WardUnit,
                                                            WardPack=@WardPack,
                                                            PhaAttr=@PhaAttr,
                                                            StorageCondition=@StorageCondition
                                                     WHERE PhaCode=@PhaCode";
                return Conn.Execute(query, obj);
            }
        }
        public int Insert(PHA_BaseInfo obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PHA_BaseInfo 
                                    VALUES(
                                            @PhaCode,
                                            @PhaName,
                                            @CommonName,
                                            @Spec,
                                            @Unit,
                                            @DosageForm,
                                            @Repo,
                                            @IsSpecial,
                                            @DispenseWay,
                                            @PinyinCode,
                                            @WubiCode,
                                            @IsAntibiotic,
                                            @IsEmergency,
                                            @IsValid,
                                            @MinUnit,
                                            @PharmacySpec,
                                            @PharmacyUnit,
                                            @PharmacyPack,
                                            @MinPack,
                                            @WardSpec,
                                            @WardUnit,
                                            @WardPack,
                                            @PhaAttr,
                                            @StorageCondition)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PHA_BaseInfo obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PHA_BaseInfo WHERE PhaCode=@PhaCode";
                return Conn.Execute(query, obj);
            }
        }
    }
}
