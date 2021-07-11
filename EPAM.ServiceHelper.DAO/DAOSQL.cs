using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.ServiceHelper.DAO
{


    public class DAOSQL
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public T Get<T> (string procedure, string[] nameParam, string[] param)
        {
            using (_connection = new SqlConnection(_connectionString))
            {               
                SqlCommand command = new SqlCommand(procedure, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                for (int i = 0; i < nameParam.Length; i++)
                {
                    command.Parameters.AddWithValue(nameParam[i], param[i]);
                }
                _connection.Open();

                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return (T)reader.GetValue(0);

                }
                return default(T);  
            }

        }
    }
}
