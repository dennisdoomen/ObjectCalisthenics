namespace GildedRose
{
    public class BackstagePasses : Item
    {
        public BackstagePasses(int sellIn, Quality quality)
            : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality)
        {
        }

        public override void UpdateQuality()
        {
            if (!Quality.IsSufficient)
            {
                Quality = Quality.Increase();

                if (SellIn < 11)
                {
                    Quality = Quality.Increase();
                }

                if (SellIn < 6)
                {
                    Quality = Quality.Increase();
                }
            }

            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                Quality = new Quality();
            }
        }
    }
}