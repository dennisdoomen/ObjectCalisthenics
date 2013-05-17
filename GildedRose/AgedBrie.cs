namespace GildedRose
{
    public class AgedBrie : Item
    {
        public AgedBrie(SellInDays sellIn, Quality quality)
            : base("Aged Brie", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            Quality = Quality.Increase();

            SellInDays = SellInDays.Decrement();
            if (SellInDays.IsOverdue)
            {
                Quality = Quality.Increase();
            }
        }
    }
}