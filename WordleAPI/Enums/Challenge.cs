using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleBackend.Enums
{
    // Types of challenge modes
    public enum Challenge
    {
        None,
        AllGreen,
        AllYellow,
        HardMode,
    }
}
