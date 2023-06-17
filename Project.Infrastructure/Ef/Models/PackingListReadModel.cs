

namespace Project.Infrastructure.Ef.Models
{
	public class PackingListReadModel
	{
        public Guid Id { get; set; }
        public int Version { get; set; }
        public string Name { get; set; }
        public LocalizationReadModel Localization { get; set; }
        public ICollection<PackingItemReadModel> items { get; set; }
    }
}
