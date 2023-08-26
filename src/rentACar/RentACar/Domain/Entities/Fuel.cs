using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Fuel : Entity<Guid>
    {
        public string Name { get; set; }
        public virtual ICollection<Model>? Models { get; set; }
    }
}
