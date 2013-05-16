namespace GildedRose
{
    public class ConjuredManaCake : Item
    {
        public ConjuredManaCake(int sellIn, Quality quality)
            : base("Conjured Mana Cake", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            Quality = Quality.Decrease();

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = Quality.Decrease();
            }
        }
    }
}