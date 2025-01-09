using Core.Common;

namespace Core.Entities
{
    public class Subject : BaseEntity, IAuditedEntity
    {
        public string SubjectName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
