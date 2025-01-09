using Core.Common;

namespace Core.Entities
{
    public class Answer : BaseEntity, IAuditedEntity
    {
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool IsTrue { get; set; } = false;
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
