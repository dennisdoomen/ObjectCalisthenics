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
                new DexterityVest(10, 20),
                new AgedBrie(2, 0),
                new ElixirOfTheMongoose(5, 7),
                new Sulfuras(0, 80),
                new BackstagePasses(15, 20),
                new ConjuredManaCake(3, 6)
            };
        }

        public void UpdateQuality(List<Item> list)
        {
            foreach (var item in list)
            {
                item.Process();
            }
        }
    }
}