using System;
using System.Collections.Generic;
using System.Linq;

using FluentAssertions;

using GuildedRose.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.Specs
{
    [TestClass]
    public class GildedRoseSpecs
    {
        private const int MaxBackstageSellin = 30;
        private const int MaxQuality = 50;
        private GildedRose gildedRose;
        private List<Item> items;
        private Random rand = new Random(3456789);

        [TestInitialize]
        public void Setup()
        {
            gildedRose = new GildedRose();
            items = gildedRose.MakeItems();
        }

        [TestMethod]
        public void After_one_day()
        {
            RepeatUpdateQuality(1);
            var itemNames = items.Select(i => i.Name);
            
            itemNames.Should().BeEquivalentTo(new[]
            {
                "+5 Dexterity Vest",
                "Aged Brie",
                "Elixir of the Mongoose",
                "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert",
                "Conjured Mana Cake"
            });
            
            var qualities = items.Select(i => i.Quality);
            qualities.Should().BeEquivalentTo(new[] { 19, 1, 6, 80, 21, 5 });
            
            var sellIns = items.Select(i => i.SellIn);
            sellIns.Should().BeEquivalentTo(new[] { 9, 1, 4, 0, 14, 2 });
        }

        [TestMethod]
        public void After_three_days()
        {
            RepeatUpdateQuality(3);
            
            var itemNames = items.Select(i => i.Name);
            itemNames.Should().BeEquivalentTo(new[]
            {
                "+5 Dexterity Vest",
                "Aged Brie",
                "Elixir of the Mongoose",
                "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert",
                "Conjured Mana Cake"
            });
            
            var qualities = items.Select(i => i.Quality);
            qualities.Should().BeEquivalentTo(new[] { 17, 4, 4, 80, 23, 3 });
            
            var sellIns = items.Select(i => i.SellIn);
            sellIns.Should().BeEquivalentTo(new[] { 7, -1, 2, 0, 12, 0 });
        }

        [TestMethod]
        public void After_a_shitload_of_days()
        {
            RepeatUpdateQuality(500);

            var itemNames = items.Select(i => i.Name);
            itemNames.Should().BeEquivalentTo(new string[]
            {
                "+5 Dexterity Vest",
                "Aged Brie",
                "Elixir of the Mongoose",
                "Sulfuras, Hand of Ragnaros",
                "Backstage passes to a TAFKAL80ETC concert",
                "Conjured Mana Cake"
            });
            
            var qualities = items.Select(i => i.Quality);
            qualities.Should().BeEquivalentTo(new int[] { 0, 50, 0, 80, 0, 0 });
            
            var sellIns = items.Select(i => i.SellIn);
            sellIns.Should().BeEquivalentTo(new int[] { -490, -498, -495, 0, -485, -497 });
        }

        [TestMethod]
        public void Backstage_pass_golden_copy()
        {
            items = ABunchOfBackstagePasses();
            RepeatUpdateQuality(11);
            
            var qualities = items.Select(i => i.Quality);
            qualities.Should().BeEquivalentTo(new int[]
            {
                0, 49, 18, 33, 0, 28, 0, 12, 34, 25, 0, 0, 50, 12, 0, 0, 11, 0, 50, 28, 0, 0, 0, 0, 45, 0, 24, 50, 31, 50, 50, 0, 0, 0, 45, 29, 
                50, 0, 0, 47, 49, 50, 27, 26, 50, 0, 27, 36, 0, 27, 46, 33, 50, 0, 50, 0, 31, 0, 0, 50, 0, 15, 0, 47, 30, 0, 0, 0, 0, 15, 0, 0, 
                36, 50, 45, 50, 37, 43, 48, 50, 13, 0, 0, 50, 39, 47, 0, 24, 30, 42, 22, 50, 0, 50, 0, 38, 41, 50, 36, 43
            });
            
            var sellIns = items.Select(i => i.SellIn);
            sellIns.Should().BeEquivalentTo(new int[]
            {
                -9, 10, 15, 6, -11, 6, -7, 18, 14, 15, -10, -11, 3, 9, -4, -4, 14, -7, 18, 0, -8, -1, -4, -7, 14, -9, 2, 11, 11, 8, 10, -4, -11, 
                -10, 15, 3, 15, -8, -2, 4, 14, 11, 8, 5, 10, -10, 0, 10, -3, 1, 8, 13, 3, -7, 11, -8, 1, -11, -5, 7, -11, 18, -7, 0, 12, -5, -6, 
                -8, -6, 12, -10, -6, 7, 7, 3, 15, 2, 8, 3, 4, 16, -7, -11, 18, 11, 5, -6, 11, 16, 5, 13, 15, -8, 11, -5, 16, 6, 2, 2, 2
            });
        }

        private void RepeatUpdateQuality(int times)
        {
            for (int i = 0; i < times; i++)
            {
                gildedRose.UpdateQuality(items);
            }
        }

        private List<Item> ABunchOfBackstagePasses()
        {
            var listOfPasses = new List<Item>();
            for (int i = 0; i < 100; i++)
            {
                listOfPasses.Add(ARandomBackstagePass());
            }

            return listOfPasses;
        }

        private int RandomSellIn()
        {
            return rand.Next(MaxBackstageSellin);
        }

        private int RandomQuality()
        {
            return rand.Next(MaxQuality);
        }

        private Item ARandomBackstagePass()
        {
            int quality = RandomQuality();
            int sellIn = RandomSellIn();
            
            return new BackstagePasses(sellIn, quality);
        }
    }
}