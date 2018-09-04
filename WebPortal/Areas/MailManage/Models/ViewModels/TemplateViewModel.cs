using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortal.Areas.MailManage.Models.ViewModels
{
    public class TemplateViewModel
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
