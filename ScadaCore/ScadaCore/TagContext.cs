using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScadaCore
{
    public class TagContext : DbContext
    {
        public DbSet<TagValue> TagValues { get; set; }
    }
}