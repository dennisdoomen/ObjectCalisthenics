namespace GildedRose
{
    public class ConjuredManaCake : Item
    {
        public ConjuredManaCake(SellInDays sellIn, Quality quality)
            : base("Conjured Mana Cake", sellIn, quality)
        {
        }

        public override void HandleDayChange()
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