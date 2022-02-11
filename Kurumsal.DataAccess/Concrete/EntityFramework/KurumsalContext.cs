using Kurumsal.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kurumsal.DataAccess.Concrete.EntityFramework
{
    public class KurumsalContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = .\; Database= Northwind; Trusted_Connection=true");

        }
        public DbSet<Product> Products{ get; set; }
        public DbSet<Category> Categories{ get; set; }
    }
}
