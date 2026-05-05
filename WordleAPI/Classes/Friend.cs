using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WordleBackend.Classes
{
    public class Friend
    {
        public long Sender { get; set; }

        public long Accepter { get; set; }

        public bool HasAccepted { get; set; }
}
}
