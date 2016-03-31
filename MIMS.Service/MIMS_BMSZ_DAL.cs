using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MIMS.Entity;

namespace MIMS.Service
{
    public class MIMS_BMSZ_DAL
    {
        #region init dbconnection
        private static readonly string connString = ConfigurationManager.ConnectionStrings["MIMS"].ConnectionString;
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



        #region CRUD using raw dapper

        public int Insert(MIMS_BMSZ obj)
        {
            using (Conn)
            {
                string query = "INSERT INTO [dbo].[MIMS_BMSZ]([SBXH],[XTSB],[BMMC],[BMCD]) VALUES(@SBXH,@XTSB,@BMMC,@BMCD)";
                return Conn.Execute(query, obj);
            }
        }

        public int Update(MIMS_BMSZ obj)
        {
            using (Conn)
            {
                string query = "UPDATE MIMS_BMSZ SET  Name=@name WHERE id =@id";
                return Conn.Execute(query, obj);
            }
        }

        public int Delete(MIMS_BMSZ obj)
        {
            using (Conn)
            {
                string query = "DELETE FROM MIMS_BMSZ WHERE id = @id";
                return Conn.Execute(query, obj);
            }
        }

        public int Delete(string id)
        {
            using (Conn)
            {
                string query = "DELETE FROM MIMS_BMSZ WHERE id = @id";
                return Conn.Execute(query, new { id = id });
            }
        }

        public IList<MIMS_BMSZ> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM MIMS_BMSZ";
                return Conn.Query<MIMS_BMSZ>(query).ToList();
            }
        }

        public MIMS_BMSZ GetEntity(string id)
        {
            MIMS_BMSZ obj;
            string query = "SELECT * FROM MIMS_BMSZ WHERE id = @id";
            using (Conn)
            {
                obj = Conn.Query<MIMS_BMSZ>(query, new { id = id }).SingleOrDefault();
                return obj;
            }
        }

        #endregion
    }
}
