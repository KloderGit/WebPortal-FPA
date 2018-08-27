using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebPortal.Areas.CrmForms.Models;
using WebPortalBuisenessLogic;

namespace WebPortal.Areas.CrmForms.Controllers
{
    [Area("CrmForms")]
    public class InviteController : Controller
    {
        ILogger logger;
        BusinessLogic logic;

        public InviteController(ILogger logger, BusinessLogic logic)
        {
            this.logger = logger;
            this.logic = logic;
        }

        Dictionary<int, string> where = new Dictionary<int, string> {
                { 123, "Из интернета" },
                { 345, "Из рекламы" },
                { 234, "От друзей" },
            };

        Dictionary<int, string> progs = new Dictionary<int, string> {
                { 333333333, "Инструктор тренажерного зала" },
                { 444444444, "Инструктор групповых программ" },
                { 555555555, "Персональный тренер" },
            };


        public IActionResult Index()
        {
            var leads = logic.GetPreparedLeads().Result;

            var leadsViewModels = leads.Select( it => new LeadViewModel { LeadId = it.Id, ContactId = it.MainContact.Id, Name = it.MainContact.Name, Phone = it.MainContact.Fields.FirstOrDefault(x=>x.Id== 54667).Values.FirstOrDefault().Value } );

            return View(leadsViewModels);
        }

        [HttpGet]
        public IActionResult InviteForm(int id)
        {
            ViewData["WhereKmown"] = where;
            ViewData["Programs"] = progs;

            var leads = logic.GetPreparedLeads().Result;

            var leadsViewModels = leads.Select(it => new LeadViewModel { LeadId = it.Id, ContactId = it.MainContact.Id, Name = it.MainContact.Name, Phone = it.MainContact.Fields.FirstOrDefault(x => x.Id == 54667).Values.FirstOrDefault().Value });

            var item = leadsViewModels.FirstOrDefault(i=>i.LeadId == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult InviteForm(LeadViewModel model)
        {
            return Ok();
        }
    }
}