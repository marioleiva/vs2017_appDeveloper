using Shop.Domain.Entities;
using Shop.Domain.Entities.Shared.Enums;
using Shop.Infrastructure.EFDataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new ShopDb())
            {
                SalesTurn turn = new SalesTurn()
                {
                    Active = true,
                    Start = DateTime.Now,
                    End = DateTime.Now,
                    Employees = new HashSet<Employe>()
                    {
                        new Employe()
                        {
                            Address = "Av La Marina 766",
                            Birthday = DateTime.Now.ToString(),
                            Nombre = "Daniel Carbajal",
                            Sex = Sex.Male,                    
                        }
                    }
                };
                db.SalesTurns.Add(turn);
                db.SaveChanges();
            }
        }
    }
}
