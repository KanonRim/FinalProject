using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using EPAM.ServiceHelper.Entities;
using EPAM.ServiceHelper.InterfaceDAO;
using System;
using NLog;

namespace EPAM.ServiceHelper.DAO
{

 
    public class DAOSQL : IDAO
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public Person AddClient(string name, string phonNumber, string comment)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                
                string[] nameParam = new string[] { "name", "phonNumber", "comment" };
                string[] param = new string[] { name, phonNumber, comment };
                var cmd = ProcedureCMD("AddClient", nameParam, param, _connection);
                return GetClient(Convert.ToInt32(cmd.ExecuteScalar()));
            }
        }

        public Employee AddEmployee(string name, string phoneNumber, string comment,Permissions perm, string passHash)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {

                string[] nameParam = new string[] { "name", "phonNumber", "comment", "perm", "passHash" };
                string[] param = new string[] { name, phoneNumber, comment,((int)perm).ToString(), passHash };
                var cmd = ProcedureCMD("AddEmployee", nameParam, param, _connection);

                var id = Convert.ToInt32(cmd.ExecuteScalar());
                    return GetEmployee(id); 
                
            };
        }

        public string GetPassHash(int IdEmployee)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetPassHash", new string[] { "IdEmployee" }, new string[] { IdEmployee.ToString() }, _connection);
                if (reader.Read())
                {
                    return (string)reader["passHash"];
                }
                else
                {
                    throw  new Exception("Failed Get Pass Hash");
                }
            
            }
        }

        public Order UpdateOrder(Order order)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string[] nameParam = new string[] { "id","idClient", "status", "dateCreation", "device", "equipment", "comment" };
                string[] param = new string[] { order.Id.ToString(), order.Client.Id.ToString(), ((int)order.Status).ToString(), order.DateCreation.ToString(), order.Device, order.Equipment, order.Comment };
                var cmd = ProcedureCMD("UpdateOrder", nameParam, param, _connection);
                return GetOrder(Convert.ToInt32(cmd.ExecuteScalar()));

            }
        }

        public void AddOrder(Status status, Person client, DateTime dateCreation, string equipment,string comment, string device)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string[] nameParam = new string[] {"idClient","status","dateCreation","device","equipment","comment" };
                string[] param = new string[] { client.Id.ToString(), ((int)status).ToString(), dateCreation.ToString(), device,equipment,comment };
                SqlDataReader reader = ProcedureReader("AddOrder", nameParam, param, _connection);
            }
        }

        public Product AddProduct(int idOrder, int idEmployee , int price, string name, string comment, DateTime dateCreation, TimeSpan term)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                string[] nameParam = new string[] { "idOrder", "idEmployee", "price", "name", "comment", "dateCreation", "termTicks" };
                string[] param = new string[] { idOrder.ToString(), idEmployee.ToString(), price.ToString(), name , comment , dateCreation.ToString(), term.Ticks.ToString()};
                SqlDataReader reader = ProcedureReader("AddWork", nameParam, param, _connection);
            }
            //todo return GetWork();
            return new Product(idOrder, idEmployee, price, name, comment, dateCreation, term);
        }

        public   IEnumerable<Product>  GetProducts(int idOrder)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("WorkInOrder",new string[] { "idOrder" }, new string[] { idOrder.ToString() }, _connection);
                while (reader.Read())
                {
                    yield return new Product(
                        idOrder: Convert.ToInt32(reader["idOrder"]),
                        idEmployee: Convert.ToInt32(reader["idEmployee"]),
                        price: Convert.ToInt32(reader["price"]),
                        name: (string)reader["name"],
                        comment: (string)reader["comment"],
                        dateCreation: (DateTime)reader["dateCreation"],
                        term: TimeSpan.FromTicks((long)reader["termTicks"])
                        );
                }
            }
        }

        public Person GetClient(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetClient", new string[] {"id" }, new string[] { id.ToString() }, _connection); 
                if (reader.Read())
                {
                    return new Person(
                    id: (int)reader["id"],
                    name: (string)reader["name"],
                    phonNumber: (string)reader["phonNumber"],
                    comment: (string)reader["comment"]);
                }
                else
                {

                    return null;
                }
            }
        }

        public IEnumerable<Person> GetClients()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetClients", _connection);
                while (reader.Read())
                {
                    yield return new Person(
                    id: (int)reader["id"],
                    name: (string)reader["name"],
                    phonNumber: (string)reader["phonNumber"],
                    comment: (string)reader["comment"]);
                }
            }
        }

        public Employee GetEmployee(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetEmployee", new string[] { "id" }, new string[] { id.ToString() }, _connection);
                if (reader.Read())
                {
                    return new Employee(
                    id: (int)reader["id"],
                    name: (string)reader["name"],
                    phonNumber: (string)reader["phonNumber"],
                    comment: (string)reader["comment"],
                    perm: (Permissions)Convert.ToInt32(reader["perm"]));
                }
                else
                {
                    return null;
                }
            }
        }

        public Employee GetEmployeeByName(string name)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetEmployeeByName", new string[] { "name" }, new string[] { name }, _connection);
                if (reader.Read())
                {
                    return new Employee(
                    id: (int)reader["id"],
                    name: (string)reader["name"],
                    phonNumber: (string)reader["phonNumber"],
                    comment: (string)reader["comment"],
                    perm: (Permissions)Convert.ToInt32(reader["perm"]));
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetEmployees", _connection);
                while (reader.Read())
                {
                    yield return new Employee(
                    id: (int)reader["id"],
                    name: (string)reader["name"],
                    phonNumber: (string)reader["phonNumber"],
                    comment: (string)reader["comment"],
                    perm: (Permissions)Convert.ToInt32(reader["perm"]));
                }
            }
        }

        public Order GetOrder(int id)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetOrder", new string[] { "id" }, new string[] { id.ToString() }, _connection);
                if (reader.Read())
                {
                    return new Order(
                    id: (int)reader["id"],
                    status:(Status)reader["status"],
                    client: GetClient((int)reader["idClient"]),
                    dateCreation:(DateTime)reader["dateCreation"],
                    device:(string)reader["device"],
                    equipment: (string)reader["equipment"],
                    comment: (string)reader["comment"]);
                    
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetOrders", _connection);
                while (reader.Read())
                {
                    yield return new Order(
                    id: (int)reader["id"],
                    status: (Status)reader["status"],
                    client: GetClient((int)reader["idClient"]),
                    dateCreation: (DateTime)reader["dateCreation"],
                    device: (string)reader["device"],
                    equipment: (string)reader["equipment"],
                    comment: (string)reader["comment"]); ;
                }
            }
        }

        public IEnumerable<Order> GetOrders(int fromId, int count)
        {
            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {
                SqlDataReader reader = ProcedureReader("GetOrders",new string[] { "fromId", "count" },new string[] { fromId.ToString(),count.ToString() }, _connection);
                while (reader.Read())
                {
                    yield return new Order(
                    id: (int)reader["id"],
                    status: (Status)reader["status"],
                    client: GetClient((int)reader["idClient"]),
                    dateCreation: (DateTime)reader["dateCreation"],
                    device: (string)reader["device"],
                    equipment: (string)reader["equipment"],
                    comment: (string)reader["comment"]); ;
                }
            }
        }



  



        private SqlDataReader ProcedureReader(string procedure, string[] nameParam, string[] param, SqlConnection _connection)
        {
            var reader = ProcedureCMD(procedure, nameParam, param, _connection).ExecuteReader();
            return reader;
        }

        private SqlCommand ProcedureCMD(string procedure, string[] nameParam, string[] param, SqlConnection _connection)
        {
            try
            {
                SqlCommand command = new SqlCommand(procedure, _connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                for (int i = 0; i < nameParam.Length; i++)
                {
                    if (nameParam[i] != "")
                        command.Parameters.AddWithValue(nameParam[i], param[i]);
                }
                _connection.Open();

                return command;
            }
            catch (Exception e )
            {
                logger.Warn(e, $"Error prozedure {procedure}");
                throw e;
            }
      
         

        }

        private SqlDataReader ProcedureReader(string procedure, SqlConnection _connection)
        {
            return ProcedureReader(procedure,new string[] {""}, new string[] { "" }, _connection);
        }


    }
}


;