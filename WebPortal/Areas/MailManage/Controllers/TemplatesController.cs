using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebPortalBuisenessLogic;

namespace WebPortal.Areas.MailManage.Controllers
{
    [Area("MailManage")]
    [Produces("application/json")]
    public class TemplatesController : Controller
    {
        ILogger logger;
        BusinessLogic logic;

        List<MailTemplate> mails = new List<MailTemplate> {
            new MailTemplate{ Id = 11, Subject = "Первое письмо", Body = "Тело первого письма." },
            new MailTemplate{ Id = 22, Subject = "Второе письмо", Body = "Тело второго письма." },
            new MailTemplate{ Id = 33, Subject = "Третье письмо", Body = "Тело третьего письма." },
            new MailTemplate{ Id = 44, Subject = "Четвертое письмо", Body = "Тело четвертого письма." },
            new MailTemplate{ Id = 55, Subject = "Пятое письмо", Body = "Тело пятого письма." },
        };


        public TemplatesController(ILogger logger, BusinessLogic logic)
        {
            this.logger = logger;
            this.logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(mails);
        }

        [HttpGet]
        public IActionResult Template()
        {
            return View();
        }
    }

    public class MailTemplate
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}