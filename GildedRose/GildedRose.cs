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

            Console.WriteLine("The highest value item is a {0} with quality {1}",
                highestValueItem,
                highestValueItem.Quality);

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
                new DexterityVest(10, new Quality(20)),
                new AgedBrie(2, new Quality(0)),
                new ElixirOfTheMongoose(5, new Quality(7)),
                new Sulfuras(0, new Quality(80)),
                new BackstagePass(15, new Quality(20)),
                new ConjuredManaCake(3, new Quality(6))
            };
        }
    }
}