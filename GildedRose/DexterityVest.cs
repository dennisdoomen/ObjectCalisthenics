using System;

namespace GildedRose
{
    public class DexterityVest : Item
    {
        public DexterityVest(int sellIn, Quality quality)
            : base("+5 Dexterity Vest", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }

            SellIn = SellIn - 1;

            if (SellIn < 0 && Quality > 0)
            {
                Quality = Quality - 1;
            }
        }
    }
}