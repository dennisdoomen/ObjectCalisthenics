using System;

namespace GildedRose
{
    public class GildedRose
    {
        public static void Main(String[] args)
        {
            var gildedRose = new GildedRose();

            Inventory inventory = gildedRose.CreateInventory();

            inventory.HandleDayChanges(5);

            var highestValueItem = inventory.HighestValued;

            Console.WriteLine("The highest valued item is {0}", highestValueItem);

            foreach (var item in inventory.Overdue)
            {
                Console.WriteLine("The item {0} is {1} day(s) overdue",
                    item,
                    item.DaysOverdue);
            }
        }

        public Inventory CreateInventory()
        {
            return new Inventory
            {
                new DexterityVest(new SellInDays(10), new Quality(20)),
                new AgedBrie(new SellInDays(2), new Quality(0)),
                new ElixirOfTheMongoose(new SellInDays(5), new Quality(7)),
                new Sulfuras(new SellInDays(0), new Quality(80)),
                new BackstagePass(new SellInDays(15), new Quality(20)),
                new ConjuredManaCake(new SellInDays(3), new Quality(6))
            };
        }
    }
}