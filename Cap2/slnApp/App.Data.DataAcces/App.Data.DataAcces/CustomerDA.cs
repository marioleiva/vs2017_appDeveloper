using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using App.Entities_Base;

namespace App.Data.DataAcces
{
    public class CustomerDA : BaseDA
    {
        public List<Customer> GetCustomer(string name) // Firma
        {
            var result = new List<Customer>();

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandText = "usp_GetCustomerxName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FullName", name));

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var customer = new Customer();
                    customer.CustomerID = reader.GetInt32Value("CustomerId");
                    customer.FirstName = reader.GetString(reader.GetOrdinal("FirstName"));

                    customer.LastName = reader.GetString(reader.GetOrdinal("LastName"));
                    customer.Company = GetStringValue(reader, "Company");
                    // reader.IsDBNull(reader.GetOrdinal("Company")) ? null : reader.GetString(reader.GetOrdinal("Company"));

                    //customer.Company = reader.GetString(reader.GetOrdinal("Company"));
                    customer.Address = reader.GetString(reader.GetOrdinal("Address"));
                    customer.City = reader.GetString(reader.GetOrdinal("City"));
                    customer.Company = GetStringValue(reader, "State");
                    //customer.State = reader.GetString(reader.GetOrdinal("State"));
                    customer.Country = reader.GetString(reader.GetOrdinal("Country"));
                    customer.PostalCode = reader.GetString(reader.GetOrdinal("PostalCode"));
                    customer.Phone = reader.GetString(reader.GetOrdinal("Phone"));

                    customer.Fax = reader.GetStringValue("Fax");

                    //customer.Fax = reader.GetString(reader.GetOrdinal("Fax"));
                    customer.Email = reader.GetString(reader.GetOrdinal("Email"));
                    customer.SupportRepId = reader.GetInt32Null("SupportRepId");
                    //customer.SupportRepId = reader.GetInt32(reader.GetOrdinal("SupportRepId"));

                    result.Add(customer);
                }
            }
            return result;
        }


        public int InsertCustomer(Customer entity)
        {
            var result = 0;

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertCustomer";

                cmd.Parameters.Add(
                    new SqlParameter("@FirstName", entity.FirstName));
                cmd.Parameters.Add(
                    new SqlParameter("@LastName", entity.LastName));
                cmd.Parameters.Add(
                    new SqlParameter("@Company", entity.Company));
                cmd.Parameters.Add(
                    new SqlParameter("@Address", entity.Address));
                cmd.Parameters.Add(
                    new SqlParameter("@City", entity.City));
                cmd.Parameters.Add(
                    new SqlParameter("@State", entity.State));
                cmd.Parameters.Add(
                    new SqlParameter("@Country", entity.Country));
                cmd.Parameters.Add(
                    new SqlParameter("@PostalCode", entity.PostalCode));
                cmd.Parameters.Add(
                    new SqlParameter("@Phone", entity.Phone));
                cmd.Parameters.Add(
                    new SqlParameter("@Fax", entity.Fax));
                cmd.Parameters.Add(
                    new SqlParameter("@Email", entity.Email));
                cmd.Parameters.Add(
                    new SqlParameter("@SupportRepId", entity.SupportRepId));

                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            return result;
        }

        public bool UpdateCustomer(Customer entity)
        {
            var result = false;

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateCustomer";
                cmd.Parameters.Add(
                    new SqlParameter("@ID", entity.CustomerID));
                cmd.Parameters.Add(
                    new SqlParameter("@Name", entity.FirstName));
                result = cmd.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public bool DeleteCustomer(int id)
        {
            var result = false;

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeleteCustomer";
                cmd.Parameters.Add(
                    new SqlParameter("@ID", id));
                result = cmd.ExecuteNonQuery() > 0;
            }
            return result;
        }

        public Customer GetArtistById(int id)
        {
            var result = new Customer();  // 
            var sql = "usp_GetCustomerId";
            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();

                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sql;
                cmd.Parameters.Add(
                    new SqlParameter("@ID", id)
                    );

                var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var artist = new Customer();
                    indice = reader.GetOrdinal("CustomerId");
                    artist.CustomerID = reader.GetInt32(indice);

                    indice = reader.GetOrdinal("FirstName");
                    artist.FirstName = reader.GetString(indice);
                    indice = reader.GetOrdinal("LastName");
                    artist.LastName = reader.GetString(indice);
                    indice = reader.GetOrdinal("Company");
                    artist.Company = reader.GetString(indice);
                    indice = reader.GetOrdinal("Address");
                    artist.Address = reader.GetString(indice);
                    indice = reader.GetOrdinal("City");
                    artist.City = reader.GetString(indice);
                    indice = reader.GetOrdinal("State");
                    artist.State = reader.GetString(indice);
                    indice = reader.GetOrdinal("Country");
                    artist.Country = reader.GetString(indice);
                    indice = reader.GetOrdinal("PostalCode");
                    artist.PostalCode = reader.GetString(indice);

                    indice = reader.GetOrdinal("Phone");
                    artist.Phone = reader.GetString(indice);
                    indice = reader.GetOrdinal("Fax");
                    artist.Fax = reader.GetString(indice);
                    indice = reader.GetOrdinal("Email");
                    artist.Email = reader.GetString(indice);

                }
            }
            return result;
        }
    }
}
