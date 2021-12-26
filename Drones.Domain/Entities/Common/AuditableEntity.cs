namespace Drones.Domain.Entities.Common
{
    public class AuditableEntity : Entity
    {
        public AuditableEntity()
        {
            DateTime dateTimeNow = DateTime.UtcNow;
            CreatedOn = dateTimeNow;
        }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public bool IsDeleted { get; set; }

        public void SetLastUpdated(string currentAdminName)
        {
            LastUpdatedBy = currentAdminName;
            LastUpdatedOn = DateTime.UtcNow;
        }
    }
}