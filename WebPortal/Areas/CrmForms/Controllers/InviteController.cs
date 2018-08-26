using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPortal.Areas.CrmForms.Models;

namespace WebPortal.Areas.CrmForms.Controllers
{
    [Area("CrmForms")]
    public class InviteController : Controller
    {
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

        IEnumerable<LeadViewModel> leads = new List<LeadViewModel>() {
                new LeadViewModel{ Id = 234, Name = "Оксана", Phone = "89432343456" },
                new LeadViewModel{ Id = 675, Name = "Стуков Сергей", Phone = "89553456544" },
                new LeadViewModel{ Id = 3456, Name = "Роман", Phone = "896547854" },
                new LeadViewModel{ Id = 1923, Name = "Иджян Илья", Phone = "896965556655" }
            };

        public IActionResult Index()
        {
            return View(leads);
        }

        [HttpGet]
        public IActionResult InviteForm(int id)
        {
            ViewData["WhereKmown"] = where;
            ViewData["Programs"] = progs;

            var item = leads.FirstOrDefault(i => i.Id == id);

            return View(item);
        }

        [HttpPost]
        public IActionResult InviteForm(LeadViewModel model)
        {
            return Ok();
        }
    }
}