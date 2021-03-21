using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Truyum.Models
{
    public class TruyumContext : DbContext
    {
        public TruyumContext() : base("TruyumContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TruyumContext, Truyum.Migrations.Configuration>("TruyumContext"));
        }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
    }

}