using System;

namespace GildedRose.Specs
{
    public class BackstagePassBuilder
    {
        private static readonly Random rand = new Random(3456789);
        private const int MaxBackstageSellin = 30;
        private const int MaxQuality = 50;

        public BackstagePass Build()
        {
            Quality quality = RandomQuality();
            Days sellIn = RandomSellIn();

            return new BackstagePass(sellIn, quality);
        }

        private Days RandomSellIn()
        {
            return new Days(rand.Next(MaxBackstageSellin));
        }

        private Quality RandomQuality()
        {
            return new Quality((uint)rand.Next(MaxQuality));
        }
    }
}