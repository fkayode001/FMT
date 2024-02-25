using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FMT.Models
{
    public class MailTrackerViewModel
    {
        [Key]
        public int Id { get; set; }
        public string ReferenceNo { get; set; }
        public string Subject { get; set; }
        public string SignedBy { get; set; }
        public string Sender { get; set; }
        [DisplayName("Document Date")]
        public DateTime DocumentDate { get; set; }
        public DateTime DateRecieved { get; set; } = DateTime.Now;
        public virtual Document Documents { get; set; }
        [DisplayName("DocumentType")]
        public int DocumentId { get; set; }
        public virtual Department Departments { get; set; }
        [DisplayName("Minuted To")]
        public int DepartmentId { get; set; }
        public string NextActionBy { get; set; }
        public DateTime? DateEntered { get; set; }
        public string? EnteredBy { get; set; }
        public string? MinutedTo { get; set; }
    }
}
