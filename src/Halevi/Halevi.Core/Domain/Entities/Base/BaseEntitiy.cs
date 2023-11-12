namespace Halevi.Core.Domain.Entities.Base
{
    public class BaseEntitiy
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Code { get; set; }

        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now.ToLocalTime());

        public bool Active { get; set; }
    }
}
