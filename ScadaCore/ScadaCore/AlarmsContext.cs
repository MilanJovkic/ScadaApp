using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ScadaCore
{
    public class AlarmsContext: DbContext
    {
        public DbSet<TriggeredAlarm> TriggeredAlarms { get; set; }
    }
}