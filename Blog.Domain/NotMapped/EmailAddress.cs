namespace Blog.Domain.NotMapped
{
    public class EmailAddress
    {
        public virtual int EmailAddressId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual List<Email> EmailsTo { get; set; }
        public virtual List<Email> EmailsCc { get; set; }
        public virtual List<Email> EmailsBcc { get; set; }
    }
}
