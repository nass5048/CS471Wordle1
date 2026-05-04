using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleBackend.Enums
{
    public enum Challenge
    {
        None,
        [Display(Name = "All Green")]

        AllGreen,
        [Display(Name = "All Yellow")]
        AllYellow,
        [Display(Name = "Hard")]
        HardMode,
    }
}
