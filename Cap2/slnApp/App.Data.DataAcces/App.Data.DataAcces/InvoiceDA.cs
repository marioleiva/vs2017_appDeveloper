using App.Entities_Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.DataAcces
{
    public class InvoiceDA : BaseDA
    {
        public int InsertInvoice(Invoice invoice)
        {
            int result = 0;
            using(IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                // Inicializando la transaccion
                var transaction = cnx.BeginTransaction();
                try
                {
                    var commandCab = cnx.CreateCommand();
                    commandCab.CommandText = "usp_InsertInvoice";
                    commandCab.CommandType = CommandType.StoredProcedure;
                    commandCab.Transaction = transaction;
                    commandCab.Parameters.Add(new SqlParameter("@CustomerId", invoice.CustomerId));
                    commandCab.Parameters.Add(new SqlParameter("@InvoiceDate", invoice.InvoiceDate));
                    commandCab.Parameters.Add(new SqlParameter("@BillingAddress", invoice.BillingAddress));
                    commandCab.Parameters.Add(new SqlParameter("@BillingCity", invoice.BillingCity));
                    commandCab.Parameters.Add(new SqlParameter("@BillingState", invoice.BillingState));
                    commandCab.Parameters.Add(new SqlParameter("@BillingCountry", invoice.BillingCountry));
                    commandCab.Parameters.Add(new SqlParameter("@BillingPostalCode", invoice.BillingPostalCode));
                    commandCab.Parameters.Add(new SqlParameter("@Total", invoice.Total));

                    var id = Convert.ToInt32(commandCab.ExecuteScalar());

                    foreach(var lines in invoice.InvoiceLine)
                    {
                        var commandDet = cnx.CreateCommand();
                        commandDet.CommandText = "usp_InsertInvoiceLine";
                        commandDet.CommandType = CommandType.StoredProcedure;
                        commandDet.Transaction = transaction;
                        commandDet.Parameters.Add(new SqlParameter("@InvoiceId", id));
                        commandDet.Parameters.Add(new SqlParameter("@TrackId", lines.TrackId));
                        commandDet.Parameters.Add(new SqlParameter("@UnitPrice", lines.UnitPrice));
                        commandDet.Parameters.Add(new SqlParameter("@Quantity", lines.Quantity));

                        commandDet.ExecuteNonQuery();
                    }

                    // confirmando la transaccion con el comit
                    transaction.Commit();

                    result = id;
                }
                catch (Exception ex)
                {
                    // Deshaciendo la transacción
                    transaction.Rollback();
                }
            }
            return result;
        }
    }
}
