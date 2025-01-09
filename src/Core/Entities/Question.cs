using Core.Common;

namespace Core.Entities
{
    public class Question : BaseEntity, IAuditedEntity
    {
        public string Text { get; set; }
        public int SubjectId { get; set; }
        public int LevelId { get; set; }
        public int AnswerId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
