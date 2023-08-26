using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model : Entity<Guid>
    {
        public Guid BrandId { get; set; }
        public Guid FuelId { get; set; }
        public Guid TransmissionId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual Fuel? Fuel { get; set; }
        public virtual Transmission? Transmission { get; set; }
        public virtual ICollection<Car>? Cars { get; set; }
    }
}
