namespace GildedRose
{
    public class AgedBrie : Item
    {
        public AgedBrie(int sellIn, int quality) : base("Aged Brie", sellIn, quality)
        {
        }

        public override void Process()
        {
            if (Quality < 50)
            {
                Quality = Quality + 1;
            }
            
            SellIn = SellIn - 1;

            if (SellIn < 0)
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }
            }
        }
    }
}