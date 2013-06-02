using System;

namespace GildedRose
{
    public class GildedRose
    {
        public static void Main(String[] args)
        {
            Inventory inventory = CreateInventory();
            
            inventory.HandleDayChanges(5);

            var highestValueItem = inventory.HighestValued;

            Console.WriteLine("The highest valued item is {0}", highestValueItem);

            foreach (var item in inventory.ExpiredItems)
            {
                Console.WriteLine("The item {0} is {1} day(s) overdue",
                    item,
                    item.DaysOverdue);
            }
        }

        public static Inventory CreateInventory()
        {
            return new Inventory
            {
                new DexterityVest(new Days(10), new Quality(20)),
                new AgedBrie(new Days(2), new Quality(0)),
                new ElixirOfTheMongoose(new Days(5), new Quality(7)),
                new Sulfuras(new Days(0)),
                new BackstagePass(new Days(15), new Quality(20)),
                new ConjuredManaCake(new Days(3), new Quality(6))
            };
        }
    }
}