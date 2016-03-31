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
    public class MIMS_TYPK_DAL
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

        public IList<MIMS_TYPK> GetList()
        {
            using (Conn)
            {
                string query = "SELECT * FROM MIMS_TYPK";
                return Conn.Query<MIMS_TYPK>(query).ToList();
            }

        }

    }
}
