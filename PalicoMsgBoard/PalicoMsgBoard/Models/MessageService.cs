using PalicoMsgBoard.Data;
using PalicoMsgBoard.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalicoMsgBoard.Models
{
    public class MessageService : IMessageService
    {
        private readonly ApplicationDbContext _context;

        public MessageService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetLatestPublicMsgs(int count)
        {
            IEnumerable<Message> PublicMsgs = _context.Messages.Where(m => m.IsPublic == true).ToList();
            return PublicMsgs.TakeLast(count);
        }
    }
}
