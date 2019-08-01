
using App.Entities_Base;
using DapperrDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaPruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            AlumnoDapperDAL alumnoDapperDAL = new AlumnoDapperDAL();
            alumnoDapperDAL.RegisterAlumno(new Alumno()
            {
                Nombre = "Phill",
                FechaNacimiento = DateTime.Now,
                TerminoEstudios = true
            });
            alumnoDapperDAL.RegisterAlumno(new Alumno()
            {
                Nombre = "Math",
                FechaNacimiento = DateTime.Now,
                TerminoEstudios = false
            });

            alumnoDapperDAL.UpdateAlumno(new Alumno()
            {
                Id = 2,
                Nombre = "Lucho II",
                FechaNacimiento = DateTime.Now,
                TerminoEstudios = false
            });


            alumnoDapperDAL.DeleteAlumno(4);

            alumnoDapperDAL.ListAllAlumno().ForEach(alumno =>
            {
                Console.WriteLine($"{alumno.Id}) {alumno.Nombre}) {alumno.FechaNacimiento}) {alumno.TerminoEstudios}");
            });

            Console.ReadKey();
        }

        private static void ListCustomers()
        {
            CustomerDapperDAL customerDapperDAL = new CustomerDapperDAL();

            customerDapperDAL.ListAllCustomersWithNameLike("A").ForEach(customer =>
            {
                Console.WriteLine(customer.CustomerID);
                Console.WriteLine(customer.FirstName);
                Console.WriteLine(customer.Email);
            });
        }

        private static void GetAnInvoice()
        {
            InvoiceDapperDAL invoiceDapperDAL = new InvoiceDapperDAL();
            var invoice = invoiceDapperDAL.GetInvoiceById(2);
            Console.WriteLine(invoice.BillingAddress);
            invoice.InvoiceLine.ForEach(line =>
            {
                Console.WriteLine(line.TrackId);
            });
            Console.ReadKey();
        }


        private static void InsertProduct()
        {
            ProductDapperDAL productDapperDAL = new ProductDapperDAL();
            productDapperDAL.RegisterProduct(new Product()
            {
                Name = "Chocolate",
                Desc = "Es un Chocolate"
            });
            productDapperDAL.RegisterProduct(new Product()
            {
                Name = "Pecana",
                Desc = "Es una Pecana"
            });
            productDapperDAL.ListAllProducts().ForEach(product =>
            {
                Console.WriteLine($"{product.Id}) {product.Name}");
            });
        }
            

    }
}
