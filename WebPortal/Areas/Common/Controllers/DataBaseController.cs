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
            return View( logic.GetDBPrograms().Adapt<IEnumerable<ProgramsViewModel>>( mapper ) );
            //return View();
        }

        public ActionResult ProgramsUpdate()
        {
            logic.UpdateEducationDB();

            return RedirectToAction( "Index" );
        }

    }
}