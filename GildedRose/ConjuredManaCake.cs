namespace GildedRose
{
    public class ConjuredManaCake : Item
    {
        public ConjuredManaCake(int sellIn, int quality)
            : base("Conjured Mana Cake", sellIn, quality)
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