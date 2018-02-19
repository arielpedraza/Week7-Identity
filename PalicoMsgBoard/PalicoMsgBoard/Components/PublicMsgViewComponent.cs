using Microsoft.AspNetCore.Mvc;
using PalicoMsgBoard.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PalicoMsgBoard.Components
{
    public class PublicMsgViewComponent : ViewComponent
    {
        private readonly IMessageService _messageService;

        public PublicMsgViewComponent(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IViewComponentResult Invoke(int count = 5)
        {
            return View(_messageService.GetLatestPublicMsgs(count));
        }
    }
}
