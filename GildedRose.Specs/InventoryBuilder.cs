using System.Linq;

namespace GildedRose.Specs
{
    internal class InventoryBuilder
    {
        private Inventory inventory = new Inventory();

        public Inventory Build()
        {
            if (!inventory.Any())
            {
                inventory = GildedRose.CreateInventory();
            }

            return inventory;
        }

        public InventoryBuilder With(BackstagePassBuilder builder)
        {
            inventory.Add(builder.Build());
            return this;
        }

        public InventoryBuilder With(Item item)
        {
            inventory.Add(item);
            return this;
        }
    }
}