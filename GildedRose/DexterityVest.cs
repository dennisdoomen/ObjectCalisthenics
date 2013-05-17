using System;

namespace GildedRose
{
    public class DexterityVest : Item
    {
        public DexterityVest(SellInDays sellIn, Quality quality)
            : base("+5 Dexterity Vest", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            Quality = Quality.Decrease();

            SellInDays = SellInDays.Decrement();

            if (SellInDays.IsOverdue)
            {
                Quality = Quality.Decrease();
            }
        }
    }
}