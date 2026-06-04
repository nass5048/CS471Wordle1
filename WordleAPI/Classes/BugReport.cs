using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleBackend.Classes
{
    public class BugReport
    {
        // Identifies which user submitted a report
        public long UserID { get; set; }

        // Identifies the type of the bug that was reported
        public BugType Type { get; set; }

        // Description of the bug from the user's report
        public string BugDescription { get; set; }
        
    }

    // Available bug types
    public enum BugType 
    { 
        UI, 
        Logic, 
        Performance,
        Other
    }

}
