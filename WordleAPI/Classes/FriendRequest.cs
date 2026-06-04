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
        // Identifies user ID of the player sending the friend request
        public long SenderID { get; set; }

        // Identifies user ID of the player receiving the friend request
        public long ReceiverID { get; set; }

        // State of the friend request
        public FriendRequestStatus Status { get; set; } = FriendRequestStatus.Pending;
    }
}
