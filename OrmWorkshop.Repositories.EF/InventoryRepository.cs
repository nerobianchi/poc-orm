using OrmWorkshop.Domain;
using OrmWorkshop.Repositories.Common;

namespace OrmWorkshop.Repositories.EF
{
	public class InventoryRepository : IInventoryRepository
	{
		private readonly IRepository repository;

		public InventoryRepository(IRepository repository)
		{
			this.repository = repository;
		}

		public void AddNewInventory(Inventory inventory)
		{
			this.repository.Save(inventory);
		}
	}
}