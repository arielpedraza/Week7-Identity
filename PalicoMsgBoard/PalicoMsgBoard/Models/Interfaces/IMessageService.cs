using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalicoMsgBoard.Models.Interfaces
{
    public interface IMessageService
    {
        IEnumerable<Message> GetLatestPublicMsgs(int count);
    }
}
