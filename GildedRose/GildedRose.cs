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
                new DexterityVest(10, new Quality(20)),
                new AgedBrie(2, new Quality(0)),
                new ElixirOfTheMongoose(5, new Quality(7)),
                new Sulfuras(0, new Quality(80)),
                new BackstagePasses(15, new Quality(20)),
                new ConjuredManaCake(3, new Quality(6))
            };
        }

        public void UpdateQuality(List<Item> list)
        {
            foreach (var item in list)
            {
                item.UpdateQuality();
            }
        }
    }
}