using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ShopBridgeDAL.Model
{
   public class InventoryItemDBContext :DbContext
    {
        public DbSet<ShopBridgeItem> ShopBridgeItems { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
         optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8NP993C\SQLEXPRESS;Initial Catalog=_Test_DB;Integrated Security=True");
        }
    }
}
