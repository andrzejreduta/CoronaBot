using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoronaBot.Models
{
    public class LogImportScheduler
    {
        public virtual long Id { get; set; }
        
        public virtual System.DateTime DateCreated { get; set; }

        public virtual string Result { get; set; }

        public virtual string SourceName { get; set; }
    }
}