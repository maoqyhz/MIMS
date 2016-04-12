using System.Collections.Generic;
using System.Collections;
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
    public class PHA_RepositoryDAL
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
                string query = "SELECT * FROM PHA_Repository";
                return Conn.Query<PHA_Repository>(query).ToList();
            }

        }
        /// <summary>
        /// 根据主键值获得一个对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PHA_Repository GetEntity(string id)
        {
            using (Conn)
            {
                string query = "SELECT * FROM PHA_Repository WHERE RepoID=@RepoID";
                return Conn.Query<PHA_Repository>(query, new { RepoID = id }).SingleOrDefault();
            }
        }

        public int Update(PHA_Repository obj)
        {
            using (Conn)
            {
                string query = @"UPDATE PHA_Repository 
                                    SET  RepoName=@RepoName,PhaNum=@PhaNum,IsValid=@IsValid WHERE RepoID =@RepoID";
                return Conn.Execute(query, obj);
            }
        }
        public int Insert(PHA_Repository obj)
        {
            using (Conn)
            {
                string query = @"INSERT INTO PHA_Repository 
                                    VALUES(@RepoID,@RepoName,@PhaNum,@IsValid)";
                return Conn.Execute(query, obj);
            }
        }
        public int Delete(PHA_Repository obj)
        {
            using (Conn)
            {
                string query = @"DELETE FROM PHA_Repository 
                                   WHERE RepoID = @RepoID";
                return Conn.Execute(query, obj);
            }
        }
    }
}
