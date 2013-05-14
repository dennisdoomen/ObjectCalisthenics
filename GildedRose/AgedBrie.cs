namespace GildedRose
{
    public class AgedBrie : Item
    {
        public AgedBrie(int sellIn, Quality quality) : base("Aged Brie", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
            
            SellIn = SellIn - 1;

            if (SellIn < 0 && Quality < 50)
            {
                Quality = Quality + 1;
            }
        }
    }
}