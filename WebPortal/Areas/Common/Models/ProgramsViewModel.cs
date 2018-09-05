using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortal.Areas.Common.Models
{
    public class ProgramsViewModel
    {
        public string Guid { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Form { get; set; }
        public string Department { get; set; }
        public IEnumerable<string> Subjects { get; set; }

    }
}
