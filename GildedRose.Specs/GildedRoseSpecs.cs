using System;
using System.Linq;

using FluentAssertions;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Specs
{
    [TestClass]
    public class GildedRoseSpecs
    {
        private const int MaxBackstageSellin = 30;
        private const int MaxQuality = 50;
        private GildedRose gildedRose;
        private Inventory inventory;
        private readonly Random rand = new Random(3456789);

        [TestInitialize]
        public void Setup()
        {
            gildedRose = new GildedRose();
            inventory = gildedRose.CreateInventory();
        }

        [TestMethod]
        public void After_one_day()
        {
            RepeatUpdateQuality(1);

            inventory.Should().Equal(new Item[]
            {
                new DexterityVest(new SellInDays(9), new Quality(19)),
                new AgedBrie(new SellInDays(1), new Quality(1)),
                new ElixirOfTheMongoose(new SellInDays(4), new Quality(6)),
                new Sulfuras(new SellInDays(0), new Quality(80)),
                new BackstagePass(new SellInDays(14), new Quality(21)),
                new ConjuredManaCake(new SellInDays(2), new Quality(5))
            });
        }

        [TestMethod]
        public void After_three_days()
        {
            RepeatUpdateQuality(3);
            
            inventory.Should().Equal(new Item[]
            {
                new DexterityVest(new SellInDays(7), new Quality(17)),
                new AgedBrie(new SellInDays(-1), new Quality(4)),
                new ElixirOfTheMongoose(new SellInDays(2), new Quality(4)),
                new Sulfuras(new SellInDays(0), new Quality(80)),
                new BackstagePass(new SellInDays(12), new Quality(23)),
                new ConjuredManaCake(new SellInDays(0), new Quality(3))
            });
        }

        [TestMethod]
        public void After_a_shitload_of_days()
        {
            RepeatUpdateQuality(500);

            inventory.Should().Equal(new Item[]
            {
                new DexterityVest(new SellInDays(-490), new Quality(0)),
                new AgedBrie(new SellInDays(-498), new Quality(50)),
                new ElixirOfTheMongoose(new SellInDays(-495), new Quality(0)),
                new Sulfuras(new SellInDays(0), new Quality(80)),
                new BackstagePass(new SellInDays(-485), new Quality(0)),
                new ConjuredManaCake(new SellInDays(-497), new Quality(0))
            });
        }

        [TestMethod]
        public void Backstage_pass_golden_copy()
        {
            inventory = ABunchOfBackstagePasses();
            RepeatUpdateQuality(11);
            
            uint[] qualities =
            {
                0, 49, 18, 33, 0, 28, 0, 12, 34, 25, 0, 0, 50, 12, 0, 0, 11, 0, 50, 28, 0, 0, 0, 0, 45, 0, 24, 50, 31, 50, 50, 0, 0, 0, 45, 29, 
                50, 0, 0, 47, 49, 50, 27, 26, 50, 0, 27, 36, 0, 27, 46, 33, 50, 0, 50, 0, 31, 0, 0, 50, 0, 15, 0, 47, 30, 0, 0, 0, 0, 15, 0, 0, 
                36, 50, 45, 50, 37, 43, 48, 50, 13, 0, 0, 50, 39, 47, 0, 24, 30, 42, 22, 50, 0, 50, 0, 38, 41, 50, 36, 43
            };

            int[] sellInDayses =
            {
                -9, 10, 15, 6, -11, 6, -7, 18, 14, 15, -10, -11, 3, 9, -4, -4, 14, -7, 18, 0, -8, -1, -4, -7, 14, -9, 2, 11, 11, 8, 10, -4, -11, 
                -10, 15, 3, 15, -8, -2, 4, 14, 11, 8, 5, 10, -10, 0, 10, -3, 1, 8, 13, 3, -7, 11, -8, 1, -11, -5, 7, -11, 18, -7, 0, 12, -5, -6, 
                -8, -6, 12, -10, -6, 7, 7, 3, 15, 2, 8, 3, 4, 16, -7, -11, 18, 11, 5, -6, 11, 16, 5, 13, 15, -8, 11, -5, 16, 6, 2, 2, 2
            };

            BackstagePass[] expectedItems = qualities.Select((quality, index) => 
                new BackstagePass(new SellInDays(sellInDayses[index]), new Quality(quality))).ToArray();

            inventory.Should().Equal(expectedItems);
        }

        private void RepeatUpdateQuality(int times)
        {
            for (int i = 0; i < times; i++)
            {
                foreach (var item in inventory)
                {
                    item.HandleDayChange();
                }
            }
        }

        private Inventory ABunchOfBackstagePasses()
        {
            var inventory = new Inventory();
            for (int i = 0; i < 100; i++)
            {
                inventory.Add(ARandomBackstagePass());
            }

            return inventory;
        }

        private SellInDays RandomSellIn()
        {
            return new SellInDays(rand.Next(MaxBackstageSellin));
        }

        private Quality RandomQuality()
        {
            return new Quality((uint)rand.Next(MaxQuality));
        }

        private Item ARandomBackstagePass()
        {
            Quality quality = RandomQuality();
            SellInDays sellIn = RandomSellIn();
            
            return new BackstagePass(sellIn, quality);
        }
    }
}