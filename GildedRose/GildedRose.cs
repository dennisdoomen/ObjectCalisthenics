
using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        public static void Main(String[] args)
        {
            var gildedRose = new GildedRose();
            gildedRose.UpdateQuality(gildedRose.MakeItems());
        }

        public List<Item> MakeItems()
        {
            return new List<Item>
            {
                new Item("+5 Dexterity Vest", 10, 20),
                new Item("Aged Brie", 2, 0),
                new Item("Elixir of the Mongoose", 5, 7),
                new Item("Sulfuras, Hand of Ragnaros", 0, 80),
                new Item("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                new Item("Conjured Mana Cake", 3, 6)
            };
        }

        public void UpdateQuality(List<Item> list)
        {
            List<Item> items = list;
            foreach (var item in items)
            {
                ProcessItem(item);
            }
        }

        private static void ProcessItem(Item item)
        {
            if ((item.Name != "Aged Brie") && (item.Name != "Backstage passes to a TAFKAL80ETC concert"))
            {
                ReduceQualityUnlessNameIsSulfuras(item);
            }
            else
            {
                HandleInsufficientQuality(item);
            }

            if (!item.Name.Equals("Sulfuras, Hand of Ragnaros"))
            {
                item.SellIn = item.SellIn - 1;
            }

            if (item.SellIn < 0)
            {
                HandleInsufficientSellIn(item);
            }
        }

        private static void ReduceQualityUnlessNameIsSulfuras(Item item)
        {
            if ((item.Quality > 0) && (item.Name != "Sulfuras, Hand of Ragnaros"))
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static void HandleInsufficientQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;

                HandleBackstagePasses(item);
            }
        }

        private static void HandleBackstagePasses(Item item)
        {
            if (item.Name.Equals("Backstage passes to a TAFKAL80ETC concert"))
            {
                UpdateQualityBasedOnQualityAndSellIn(item);
            }
        }

        private static void UpdateQualityBasedOnQualityAndSellIn(Item item)
        {
            if ((item.SellIn < 11) && (item.Quality < 50))
            {
                item.Quality = item.Quality + 1;
            }

            if ((item.SellIn < 6) && (item.Quality < 50))
            {
                item.Quality = item.Quality + 1;
            }
        }

        private static void HandleInsufficientSellIn(Item item)
        {
            if (item.Name != "Aged Brie")
            {
                HandleItemsThatAreNotAgedBrie(item);
            }
            else
            {
                HandleOtherItems(item);
            }
        }

        private static void HandleItemsThatAreNotAgedBrie(Item item)
        {
            if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                IfNotSulfurasAndQualityIsSufficient(item);
            }
            else
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        private static void IfNotSulfurasAndQualityIsSufficient(Item item)
        {
            if ((item.Quality > 0) && (item.Name != "Sulfuras, Hand of Ragnaros"))
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static void HandleOtherItems(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }
    }
}