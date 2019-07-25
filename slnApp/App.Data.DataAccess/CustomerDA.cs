using App.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAccess
{
    public class CustomerDA : BaseDA
    {
        public List<Customer> getCustomerxName(string name)
        {
            var resultado = new List<Customer>();

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandText = "usp_GetCustomerxName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Name", name));

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var customer = new Customer();
                    customer.CustomerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                    customer.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));
                    customer.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    customer.Company = reader.GetString(reader.GetOrdinal("Company"));
                    customer.Address = reader.GetString(reader.GetOrdinal("Address"));
                    customer.City= reader.GetString(reader.GetOrdinal("City"));
                    customer.State = reader.GetString(reader.GetOrdinal("State"));
                    customer.Country = reader.GetString(reader.GetOrdinal("Country"));
                    customer.PostalCode = reader.GetString(reader.GetOrdinal("PostalCode"));
                    customer.Phone = reader.GetString(reader.GetOrdinal("Phone"));
                    customer.Fax = reader.GetString(reader.GetOrdinal("Fax"));
                    customer.Email = reader.GetString(reader.GetOrdinal("Email"));
                    customer.SupportRepId = reader.GetInt32(reader.GetOrdinal("SupportRepId"));

                    resultado.Add(customer);
                }
            }

            return resultado;
        }
    }
}
