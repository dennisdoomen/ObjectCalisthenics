namespace GildedRose
{
    public class BackstagePasses : Item
    {
        public BackstagePasses(SellInDays sellIn, Quality quality)
            : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (!Quality.IsSufficient)
            {
                Quality = Quality.Increase();

                if (SellInDays < 11)
                {
                    Quality = Quality.Increase();
                }

                if (SellInDays < 6)
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