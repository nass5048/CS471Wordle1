using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleAPI.Classes;

public class Login
{
    public long UserID { get; set; }

    public string Username { get; set; }

    public string Password { get; set; } //TODO need to implement hash and salt for security
}
