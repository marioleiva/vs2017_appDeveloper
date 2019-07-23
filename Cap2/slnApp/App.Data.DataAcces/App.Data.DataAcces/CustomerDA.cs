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
        public List<Customer> GetCustomer(string filtroPorNombre) // Firma
        {
            var result = new List<Customer>();

            var sql = "usp_GetCustomer";
            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                // COnfigurar parametros
                cmd.Parameters.Add(
                    new SqlParameter("@Nombre", filtroPorNombre)
                    );
                //var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var customer = new Customer();
                    // MAPEO DE DATOS
                    customer.CustomerID = reader.GetInt32(0);
                    customer.FirstName = reader.GetString(1);
                    customer.LastName = reader.GetString(2);
                    //customer.Company = reader.GetString(3);
                    customer.Address = reader.GetString(4);
                    customer.City = reader.GetString(5);
                    //customer.State = reader.GetString(6);
                    customer.Country = reader.GetString(7);
                    customer.PostalCode = reader.GetString(8);
                    customer.Phone = reader.GetString(9);
                    //customer.Fax = reader.GetString(10);
                    customer.Email = reader.GetString(11);
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
                    new SqlParameter("@SupportRepId", 3));

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
