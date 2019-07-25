using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App.Data.DataAcces;
using App.Entities_Base;

namespace App.Data.DataAccessTest
{
    /// <summary>
    /// Descripción resumida de CustomerDATest
    /// </summary>
    [TestClass]
    public class CustomerDATest
    {
        //[TestMethod]
        //public void GetCustomerWithSP()
        //{
        //    var da = new CustomerDA();
        //    var listado = da.GetCustomer("Leo%");
        //    Assert.IsTrue(listado.Count > 0);
        //}

        //[TestMethod]
        //public void InsertCustomerWithSP()
        //{
        //    var customer = new Customer();
        //    customer.FirstName = "Artista prueba";
        //    customer.LastName = "Artista prueba";
        //    customer.Company = "Artista prueba";
        //    customer.Address = "Artista prueba";
        //    customer.City = "Artista prueba";
        //    customer.State = "Artista prueba";
        //    customer.Country = "Artista prueba";
        //    customer.PostalCode = "3";
        //    customer.Phone = "Artista prueba";
        //    customer.Fax = "Artista prueba";
        //    customer.Email = "Artista prueba";
        //    //artist.Name = "Artista prueba";

        //    var da = new CustomerDA();
        //    var codigoGenerado = da.InsertCustomer(customer);
        //    Assert.IsTrue(codigoGenerado > 0);
        //}
        

        //[TestMethod]
        //public void UpdateCustomer()
        //{
        //    var customer = new Customer();
        //    customer.FirstName = "cliente prueba nuevo";


        //    var da = new CustomerDA();
        //    var codigoGenerado = da.InsertCustomer(customer);
        //    // actualizado
        //    customer.FirstName = "cliente nuevo actualizado";
        //    customer.CustomerID = codigoGenerado;
        //    var updated = da.UpdateCustomer(customer);
        //    Assert.IsTrue(updated);

        //    var customerUpdated = da.GetArtistById(codigoGenerado);
        //    Assert.IsTrue(customerUpdated.FirstName == "Artista nuevo actualizado");
        //}

        //[TestMethod]
        //public void DeleteArtist()
        //{
        //    var id = 77;
        //    var da = new CustomerDA();
        //    var codigoGenerado = da.DeleteCustomer(id);
        //    Assert.IsTrue(codigoGenerado);
        //}
    }
}
