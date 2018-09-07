using Mapster;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Collections.Generic;
using WebPortal.Areas.Common.Models;
using WebPortalBuisenessLogic;
using WebPortalBuisenessLogic.Models.DataBase;

namespace WebPortal.Areas.Common.Controllers
{
    [Area("Common")]
    public class DataBaseController : Controller
    {
        ILogger logger;
        BusinessLogic logic;
        TypeAdapterConfig mapper;

        public DataBaseController(ILogger logger, BusinessLogic logic, TypeAdapterConfig mapping)
        {
            this.logger = logger;
            this.logic = logic;
            this.mapper = mapping;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var aaa = new ProgramDTO() { Title = "asdadasd", Form = "OOO", Department = "SSS" };
            var ttt = aaa.Adapt<ProgramsViewModel>(mapper);

            var ttttt = logic.GetDataBasePrograms().Adapt<IEnumerable<ProgramsViewModel>>(mapper);

            return View();
        }

        public ActionResult Programs()
        {
            var programs = logic.GetDataBasePrograms();

            return View(programs.Adapt<IEnumerable<ProgramsViewModel>>(mapper));
        }

        public IActionResult UpdatePrograms()
        {
            var programs = logic.UpdateDataBasePrograms();

            return RedirectToAction("Programs");
        }
    }
}