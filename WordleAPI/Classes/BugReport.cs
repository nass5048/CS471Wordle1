using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleBackend.Classes
{
    public class BugReport
    {
        public long UserID { get; set; }

        public BugType Type { get; set; }

        public string BugDescription { get; set; }
        
    }
    public enum BugType 
    { 
        UI, 
        Logic, 
        Performance,
        Other
    }

}
