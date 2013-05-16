namespace GildedRose
{
    public class AgedBrie : Item
    {
        public AgedBrie(int sellIn, Quality quality) : base("Aged Brie", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            Quality = Quality.Increase();

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = Quality.Increase();
            }
        }
    }
}