using System;
using System.Collections.Generic;
using App.Data.DataAcces;
using App.Entities_Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.DataAccessTest
{
    [TestClass]
    public class InvoiceDATest
    {
        [TestMethod]
        public void Insert()
        {
            var invoice = new Invoice();
            invoice.CustomerId = 1;
            invoice.InvoiceDate = DateTime.Now;
            invoice.BillingAddress = "";
            invoice.BillingCity = "";
            invoice.BillingState = "";
            invoice.BillingCountry = "";
            invoice.BillingPostalCode = "";
            invoice.Total = 100;

            invoice.InvoiceLine = new List<InvoiceLine>();
            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 1,
                    UnitPrice = 10,
                    Quantity = 3
                });
            invoice.InvoiceLine.Add(
                new InvoiceLine()
                {
                    TrackId = 2,
                    UnitPrice = 12,
                    Quantity = 7
                });

            var da = new InvoiceDA();
            var codigoGenerado = da.InsertInvoice(invoice);
            Assert.IsTrue(codigoGenerado > 0);

        }
    }
}
