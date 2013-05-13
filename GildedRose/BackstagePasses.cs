namespace GildedRose
{
    public class BackstagePasses : Item
    {
        public BackstagePasses(int sellIn, int quality)
            : base("Backstage passes to a TAFKAL80ETC concert", sellIn, quality)
        {
        }

        public override void Process()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
                
                if (SellIn < 11)
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }

                if (SellIn < 6)
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }
            }

            if (true)
            {
                SellIn = SellIn - 1;
            }

            if (SellIn < 0)
            {
                Quality = Quality - Quality;
            }
        }
    }
}