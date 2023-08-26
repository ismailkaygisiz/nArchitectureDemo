using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Transmission : Entity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Model>? Models { get; set; }
    }
}
