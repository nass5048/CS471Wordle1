using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleBackend.Classes
{
    public class DailyWords
    {
        // Date with the daily Wordle
        public DateOnly Date { get; set; }

        // Word assigned to the specified date
        public string Word { get; set; }
    }
}
