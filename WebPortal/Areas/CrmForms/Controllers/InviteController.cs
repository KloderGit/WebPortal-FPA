using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mapster;
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
        TypeAdapterConfig mapper;

        public InviteController(ILogger logger, BusinessLogic logic, TypeAdapterConfig mapping)
        {
            this.logger = logger;
            this.logic = logic;
            this.mapper = mapping;
        }

        Dictionary<int, string> progs = new Dictionary<int, string> {
            { 489751, "Инструктор тренажерного зала" },
            { 489753, "Персональный фитнес-тренер" },
            { 489755, "Инструктор групповых программ" },
        };

        // Список сделок на статусе - Пришел в офис
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var leads = await logic.GetPreparedLeads();

            var wizardViewModels = leads?.Adapt<IEnumerable<WizardViewModel>>(mapper);

            return View(wizardViewModels);
        }

        // Выбраная сделка
        [HttpGet]
        public async Task<IActionResult> UpdateLeadAndContactFromWizard(int id)
        {
            ViewData["Programs"] = progs;

            ViewData["Controller"] = this.ControllerContext.RouteData.Values["controller"].ToString();
            ViewData["Action"] = this.ControllerContext.RouteData.Values["action"].ToString();

            var it = await logic.GetLeadById(id);

            var wizardViewModels = it.Adapt<WizardViewModel>(mapper);

            return View(wizardViewModels);
        }

        // Отправка выбраной сделки
        [HttpPost]
        public async Task<IActionResult> UpdateLeadAndContactFromWizard(WizardViewModel model)
        {
            var modelDTo = model.Adapt<WizardDTO>(mapper);

            try
            {
                await logic.UpdateLeadAndContact(modelDTo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}