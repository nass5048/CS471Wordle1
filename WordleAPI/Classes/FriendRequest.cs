using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleBackend.Enums;

namespace WordleBackend.Classes
{
    public class FriendRequest
    {
        public long SenderID { get; set; }

        public long ReceiverID { get; set; }

        public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Pending;
    }
}
