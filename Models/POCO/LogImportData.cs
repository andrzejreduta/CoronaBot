using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaBot.Models
{
    public class LogImportData
    {
        public virtual long Id { get; set; }

        public virtual System.DateTime DateCreated { get; set; }

        public virtual string RegionName { get; set; }

        public virtual string SourceName { get; set; }

        public virtual int CasesTotal { get; set; }

        public virtual int CasesNew { get; set; }

        public virtual int DeathsTotal { get; set; }

        public virtual int DeathsNew { get; set; }

        public virtual int RecoveredTotal { get; set; }

        public virtual int Active { get; set; }

        public virtual int ActiveCritical { get; set; }

        public virtual int RatioCasesTo1M { get; set; }
    }
}
