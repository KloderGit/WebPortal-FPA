using Domain.Models.Education;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPortal.Areas.Common.Models;

namespace WebPortal.Infrastructure.Mappings
{
    public class ViewModelMaps
    {
        public ViewModelMaps(TypeAdapterConfig mapper)
        {
            mapper.NewConfig<EducationProgram, ProgramsViewModel>()
                .Map( dest => dest.Department, src => src.Department.Title )
                .Map( dest => dest.Form, src => src.EducationForm.Title )
                .Map( dest => dest.Subjects, src => src.Subjects.Select( s => s.Title ) );
        }
    }
}
