using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebPortal.Areas.CrmForms.Models;
using WebPortalBuisenessLogic;
using WebPortalBuisenessLogic.Models.Crm;

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

        Dictionary<int, string> progs = new Dictionary<int, string> {
            { 489751, "Инструктор тренажерного зала" },
            { 489753, "Персональный фитнес-тренер" },
            { 489755, "Инструктор групповых программ" },
            { 489761, "Стажировка" },
            { 489763, "Мастер тренер" },
            { 489765, "Элит тренер" }
        };

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var leads = await logic.GetPreparedLeads();

            var leadsViewModels = leads.Select( it => new LeadViewModel { LeadId = it.LeadId, ContactId = it.ContactId, Name = it.Name, Phone = it.Phone, Email = it.Email  } );

            return View(leadsViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> InviteForm(int id)
        {
            ViewData["Programs"] = progs;

            ViewData["Controller"] = this.ControllerContext.RouteData.Values["controller"].ToString();
            ViewData["Action"] = this.ControllerContext.RouteData.Values["action"].ToString();

            var it = await logic.GetLeadById(id);

            var leadViewModels = new LeadViewModel { LeadId = it.LeadId, ContactId = it.ContactId, Name = it.Name, Phone = it.Phone, Email = it.Email };

            return View(leadViewModels);
        }

        [HttpGet]
        public IActionResult InviteAddForm()
        {
            ViewData["Programs"] = progs;

            ViewData["Controller"] = this.ControllerContext.RouteData.Values["controller"].ToString();
            ViewData["Action"] = this.ControllerContext.RouteData.Values["action"].ToString();

            var leadViewModels = new LeadViewModel();

            return View(leadViewModels);
        }

        [HttpPost]
        public IActionResult InviteAddForm(LeadViewModel model)
        {
            var modelDTo = new UpdateFormDTO
            {
                Birthday = model.Birthday,
                City = model.City,
                ContactId = model.ContactId,
                Education = model.Education,
                Email = model.Email,
                Expirience = model.Expirience,
                LeadId = model.LeadId,
                Name = model.Name,
                Phone = model.Phone,
                Program = model.Program,
                ProgramPart = model.ProgramPart,
                Subway = model.Subway,
                WhereKnown = model.WhereKnown
            };

            var result = logic.AddFromForm(modelDTo);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> InviteForm(LeadViewModel model)
        {
            var modelDTo = new UpdateFormDTO {
                Birthday = model.Birthday,
                City = model.City,
                ContactId = model.ContactId,
                Education = model.Education,
                Email = model.Email,
                Expirience = model.Expirience,
                LeadId = model.LeadId,
                Name = model.Name,
                Phone = model.Phone,
                Program = model.Program,
                ProgramPart = model.ProgramPart,
                Subway = model.Subway,
                WhereKnown = model.WhereKnown
            };

            await logic.UpdateForm(modelDTo);

            return Ok();
        }
    }
}