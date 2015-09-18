using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Kn222gn_IndividuellaArbetet.DAL
{
    public class DALBase
    {
        private static readonly string _connectionString;

        //Skapar en instans för Sql-uppkopplingen
        protected SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        static DALBase()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["UD14_kn222gn_IndividuellaarbetetV2"].ConnectionString;
        }
    }
}