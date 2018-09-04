using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPortal.Areas.Common.Models;
using WebPortalBuisenessLogic.Models.DataBase;

namespace WebPortal.Tools.Mapster
{
    public class RegMapster
    {
        public RegMapster(TypeAdapterConfig mapper)
        {
            mapper.NewConfig<ProgramDTO, ProgramsViewModel>();
        }


    }
}
