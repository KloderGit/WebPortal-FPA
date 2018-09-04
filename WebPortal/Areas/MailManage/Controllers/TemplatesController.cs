using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebPortal.Areas.MailManage.Models;
using WebPortal.Areas.MailManage.Models.ViewModels;
using WebPortalBuisenessLogic;

namespace WebPortal.Areas.MailManage.Controllers
{
    [Area("MailManage")]
    [Produces("application/json")]
    public class TemplatesController : Controller
    {
        ILogger logger;
        BusinessLogic logic;
        TypeAdapterConfig mapper;

        List<MailTemplate> mails = new List<MailTemplate> {
            new MailTemplate{ Id = 11, Subject = "Первое письмо", Body = "Тело первого письма." },
            new MailTemplate{ Id = 22, Subject = "Второе письмо", Body = "Тело второго письма." },
            new MailTemplate{ Id = 33, Subject = "Третье письмо", Body = "Тело третьего письма." },
            new MailTemplate{ Id = 44, Subject = "Четвертое письмо", Body = "Тело четвертого письма." },
            new MailTemplate{ Id = 55, Subject = "Пятое письмо", Body = "Тело пятого письма." },
        };


        public TemplatesController(ILogger logger, BusinessLogic logic, TypeAdapterConfig mapping)
        {
            this.logger = logger;
            this.logic = logic;
            this.mapper = mapping;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(mails);
        }


        [HttpGet]
        public IActionResult AddTemplate(int id)
        {
            var item = mails.FirstOrDefault(i => i.Id == id);
            var model = new TemplateViewModel {
                Id = item.Id,
                Subject = item.Subject,
                Body = item.Body
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddTemplate(TemplateViewModel model)
        {


            return RedirectToRoute("Index");
        }
    }
}