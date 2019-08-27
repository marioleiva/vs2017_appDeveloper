using App.Postpago.Entity;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Postpago.EFDataContext
{
    public class AppDb : DbContext
    {
        public DbSet<ClaroCanales> Canales { get; set; }
        public DbSet<ClaroCanalesPlus> CanalesPlus { get; set; }
        public DbSet<ClaroTotalCanales> CanalesTotal { get; set; }

        public AppDb() : base("appDb")  
        {

        }
    }
}
