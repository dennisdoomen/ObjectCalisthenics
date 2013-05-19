using System;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose
{
    public class GildedRose
    {
        public static void Main(String[] args)
        {
            var gildedRose = new GildedRose();
            
            List<Item> items = gildedRose.MakeItems();

            foreach (var item in items)
            {
                for (int days = 0; days < 5; days++)
                {
                    item.UpdateQuality();
                }
            }

            var highestValueItem = items.OrderBy(i => i.Quality).Last();
            Console.WriteLine("The highest value item is a {0} with quality {1}", 
                highestValueItem, 
                highestValueItem.Quality);

            IEnumerable<Item> itemsOverdue = items.Where(i => i.SellInDays.IsOverdue);
            foreach (var item in itemsOverdue)
            {
                Console.WriteLine("The item {0} is {1} day(s) overdue",
                    item,
                    item.SellInDays.DaysOverdue);
            }
        }

        public List<Item> MakeItems()
        {
            return new List<Item>
            {
                new DexterityVest(10, new Quality(20)),
                new AgedBrie(2, new Quality(0)),
                new ElixirOfTheMongoose(5, new Quality(7)),
                new Sulfuras(0, new Quality(80)),
                new BackstagePasses(15, new Quality(20)),
                new ConjuredManaCake(3, new Quality(6))
            };
        }
    }
}