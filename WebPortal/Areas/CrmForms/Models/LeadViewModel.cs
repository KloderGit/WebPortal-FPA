using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortal.Areas.CrmForms.Models
{
    public class LeadViewModel
    {
        public int LeadId { get; set; }
        public int ContactId { get; set; }
        public string Name { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string Birthday { get; set; }
        public int WhereKnown { get; set; }

        public string City { get; set; }
        public string Subway { get; set; }
        public string Education { get; set; }

        public string Expirience { get; set; }

        public int Program { get; set; }
        public int ProgramPart { get; set; }
    }
}
