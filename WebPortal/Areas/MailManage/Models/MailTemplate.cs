namespace WebPortal.Areas.MailManage.Models
{
    public class MailTemplate
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public byte[] Picture { get; set; }
    }
}
