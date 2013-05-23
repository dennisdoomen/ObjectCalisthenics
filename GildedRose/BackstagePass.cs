namespace GildedRose
{
    public class BackstagePass : Item
    {
        public BackstagePass(SellInDays sellIn, Quality quality)
            : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality)
        {
        }

        public override void HandleDayChange()
        {
            if (!Quality.IsSufficient)
            {
                Quality = Quality.Increase();

                if (SellInDays < new SellInDays(11))
                {
                    Quality = Quality.Increase();
                }

                if (SellInDays < new SellInDays(6))
                {
                    Quality = Quality.Increase();
                }
            }

            SellInDays = SellInDays.Decrement();
            if (SellInDays.IsOverdue)
            {
                Quality = new Quality();
            }
        }
    }
}